using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketService.Controllers.api.Models;
using TicketService.Core;
using TicketService.Core.Queries;
using TicketService.DAL.Models;

namespace TicketService.Controllers.api
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;
        private readonly IMapper mapper;

        public EventController(IEventService eventService, IMapper mapper)
        {
            this.eventService = eventService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventResource>), StatusCodes.Status200OK)]
        [Produces("application/json", "application/xml", "text/csv")]
        public async Task<IEnumerable<EventResource>> GetEvents([FromQuery] EventQuery query)
        {
            var pagedResult = await eventService.GetEvents(query);
            HttpContext.Response.Headers.Add("x-total-count", pagedResult.count.ToString());

            return mapper.Map<IEnumerable<EventResource>>(pagedResult.items);
        }

        [HttpGet("filterByName")]
        [ProducesResponseType(typeof(IEnumerable<String>), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IEnumerable<String>> GetEventNames([FromQuery] string eventName)
        {
            return await eventService.GetEventNames(eventName);
        }

    }
}
