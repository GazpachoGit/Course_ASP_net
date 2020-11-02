using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketService.Core;
using TicketService.DAL.Models;
using TicketService.Models;

namespace TicketService.Controllers
{
    public class TicketsController : Controller
    {

        private readonly ITicketsService ticketsService;
        private readonly IEventService eventService;
        private readonly IOrderService orderService;
        private readonly UserManager<IdentityUser> userService;

        public TicketsController(ITicketsService ticketsService, IEventService eventService, UserManager<IdentityUser> userService, IOrderService orderService)
        {
            this.eventService = eventService;
            this.userService = userService;
            this.ticketsService = ticketsService;
            this.orderService = orderService;
        }

        [Route("Events/{id}/Tickets")]
        public async Task<IActionResult> Tickets(int id)
        {
            var Tickets = await ticketsService.GetTicketsAvailableByEventId(id);
            return View(Tickets);
        }
        public async Task<IActionResult> CreateView(int eventId)
        {
            var Sellers = await userService.Users.ToListAsync();
            ViewBag.user = Sellers.FirstOrDefault(u => u.UserName == User.Identity.Name);
            ViewBag.Sellers = new SelectList(Sellers, "Id", "UserName", ViewBag.user.Id);
            ViewBag.Event = await eventService.GetEventById(eventId);
            return View();
        }
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {

            await ticketsService.CreateTicket(ticket);
            return LocalRedirect($"/Events/{ticket.EventId}/Tickets");

        }
        [Authorize]
        public async Task<IActionResult> BuyTicket(int ticketId)
        {
            var user = await userService.GetUserAsync(User);
            var ticket = await ticketsService.GetTicket(ticketId);
            if (ticket.SellerId == user.Id)
            {
                TempData["BuyTicketError"] = "Can't buy self tickets";
                return RedirectToAction("Index", "Events");
            }
            else
            {
                await ticketsService.BuyTicket(ticketId);
                await orderService.CreateOrder(ticketId, user.Id);
                return RedirectToAction("Index", "Events");
            }           
        }
    }
}
