using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketService.Database;
using TicketService.Models.TestData;

namespace TicketService.Controllers
{
    public class TicketsController : Controller
    {
        
        private readonly TicketServiceContext context;

        public TicketsController( TicketServiceContext context)
        {
           
            this.context = context;
        }

        [Route("Event/{id}/Tickets")]
        public async Task<IActionResult> Tickets(int id)
        {
            var Tickets = await context.Tickets.Where(t => t.Event.EventId == id).Include(t => t.Event).Include(t => t.Seller).ToListAsync();            
            return View(Tickets);
        }
    }
}
