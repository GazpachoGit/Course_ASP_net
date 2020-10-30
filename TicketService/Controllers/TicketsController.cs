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
        private readonly UserManager<IdentityUser> userService;

        public TicketsController(ITicketsService ticketsService, IEventService eventService, UserManager<IdentityUser> userService)
        {
            this.eventService = eventService;
            this.userService = userService;
            this.ticketsService = ticketsService;
        }

        [Route("Event/{id}/Tickets")]
        public async Task<IActionResult> Tickets(int id)
        {
            var Tickets = await ticketsService.GetTicketsAvailableByEventId(id);
            return View(Tickets);
        }
        public async Task<IActionResult> CreateView(int eventId)
        {
 //           var Sellers = await userService.GetAllUsersNames();
 //           ViewBag.Sellers = new SelectList(Sellers, "Id", "UserName");
            ViewBag.Event = await eventService.GetEventById(eventId);
            return View();
        }
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {

            await ticketsService.CreateTicket(ticket);
            return LocalRedirect($"/Event/{ticket.EventId}/Tickets");

        }
        [Authorize]
        public async Task<IActionResult> BuyTicket(int ticketId)
        {
            await ticketsService.BuyTicket(ticketId);
            return RedirectToAction("Event", "Index");
        }
    }
}
