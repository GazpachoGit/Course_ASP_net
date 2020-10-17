using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketService.Core;
using TicketService.Models;

namespace TicketService.Controllers
{
    public class TicketsController : Controller
    {
        
        private readonly ITicketsService ticketsService;

        public TicketsController(ITicketsService ticketsService)
        {
           
            this.ticketsService = ticketsService;
        }

        [Route("Event/{id}/Tickets")]
        public async Task<IActionResult> Tickets(int id)
        {
            var Tickets = await ticketsService.GetTicketsByEventId(id);            
            return View(Tickets);
        }
    }
}
