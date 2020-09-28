using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketService.Models;
using TicketService.Models.TestData;

namespace TicketService.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private TestData testData;

        public EventsController(TestData testData) {
            this.testData = testData;
        }
        
        [HttpGet()]
        public IActionResult GetEvents()
        {
            var Events = testData.Events; 
            return Ok(Events);
        }
    }
}
