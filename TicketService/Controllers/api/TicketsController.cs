using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketService.Models;
using TicketService.Models.TestData;

namespace TicketService.Controllers.api
{
    [ApiController]
    [Route("api/Events/{eventId}/Tickets")]
    public class TicketsController : Controller
    {
        private TestData testData;

        public TicketsController(TestData testData)
        {
            this.testData = testData;
        }

        [HttpGet()]
        public IActionResult GetEventTickets([FromRoute] int eventId)
        {
            var Tickets = testData.Tickets.Where(t => t.Event.Id == eventId);
            return Ok(Tickets);
        }
    }
}
