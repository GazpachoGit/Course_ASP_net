using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TicketService.Core;

namespace TicketService.Controllers
{
    public class MyTicketsController : Controller
    {
        private readonly ITicketsService ticketsService;
        private readonly IOrderService orderService;
        private readonly UserManager<IdentityUser> userService;

        public MyTicketsController(ITicketsService ticketsService, IOrderService orderService, UserManager<IdentityUser> userService)
        {
            this.orderService = orderService;
            this.ticketsService = ticketsService;
            this.userService = userService;
        } 
        public async Task<IActionResult> Index()
        {
            var username = User.Identity.Name;
            var tickets = await ticketsService.GetTicketsByUsername(username);
            ViewBag.Orders = await orderService.GetOrdersOnTickets(tickets);
            return View(tickets);
        }
        public async Task<IActionResult> ApproveTicket(int ticketId, int orderId)
        {
            
            await ticketsService.ApproveTicket(ticketId);
            await orderService.ConfirmOrder(orderId);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RejectTicket(int ticketId, int orderId)
        {
            await orderService.RejectOrder(orderId);
            if (await ticketsService.TicketOrderExist(ticketId)) 
            {
                await ticketsService.RejectTicket(ticketId);
            }
            return RedirectToAction("Index");
        }

    }
}
