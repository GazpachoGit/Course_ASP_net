using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketService.Models.TestData;

namespace TicketService.Controllers
{
    public class TicketsController : Controller
    {
        private TestData testData;

        public TicketsController(TestData testData)
        {
            this.testData = testData;
        }

        [Route("Event/{id}/Tickets")]
        public IActionResult Tickets(int id)
        {
            var Tickets = testData.Tickets.Where(t => t.Event.Id == id);
            return View(Tickets);
        }
    }
}
