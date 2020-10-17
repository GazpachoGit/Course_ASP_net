using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using TicketService.Core;
using TicketService.Models;

namespace TicketService.Controllers
{
    public class EventsController : Controller
    {
        
        private readonly IEventService eventService;

        public EventsController(IEventService eventService)
        {
            
            this.eventService = eventService;
        }


        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var Events = await eventService.GetAllEvents();
            return View(Events);
        }

       [Route("Events/{id}")]
        public async Task<IActionResult> Details(int id)
        {

            var Event = await eventService.GetEventById(id);
            return View(Event);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
