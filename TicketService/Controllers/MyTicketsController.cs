using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketService.Core;

namespace TicketService.Controllers
{
    public class MyTicketsController : Controller
    {
        private readonly ITicketsService ticketsService;
        

        public MyTicketsController(ITicketsService ticketsService)
        {
            
            this.ticketsService = ticketsService;
        } 
        public async Task<IActionResult> Index()
        {
            var username = User.Identity.Name;
            var tickets = await ticketsService.GetTicketsByUsername(username);            
            return View(tickets);
        }
        public async Task<IActionResult> ApproveTicket(int ticketId)
        {
            await ticketsService.ApproveTicket(ticketId);
            return RedirectToAction("Index");
        }
    }
}
