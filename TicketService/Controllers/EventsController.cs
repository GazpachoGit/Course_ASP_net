using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using TicketService.Models;
using TicketService.Models.TestData;

namespace TicketService.Controllers
{
    public class EventsController : Controller
    {
        private TestData testData;

        public EventsController(TestData testData)
        {
            this.testData = testData;
        }


        [HttpGet()]
        public IActionResult Index()
        {
            var Events = testData.Events;
            return View(Events);
        }
       [Route("Events/{id}")]
        public IActionResult Details(int id)
        {
            var Event = testData.Events.FirstOrDefault(e => e.Id.Equals(id));
            return View(Event);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
