using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using TicketService.Database;
using TicketService.Models;
using TicketService.Models.TestData;

namespace TicketService.Controllers
{
    public class EventsController : Controller
    {
        
        private readonly TicketServiceContext context;

        public EventsController( TicketServiceContext context)
        {
            
            this.context = context;
        }


        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var Events = await context.Events.Include(e => e.Venue).ThenInclude(v => v.City).ToListAsync();
            return View(Events);
        }

       [Route("Events/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            
            var Event = await context.Events.Include(e => e.Venue).ThenInclude(v => v.City).SingleOrDefaultAsync(e => e.EventId == id);
            return View(Event);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
