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

namespace TicketService.Controllers.api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketsService ticketsService;
        private readonly IMapper mapper;

        public TicketController(ITicketsService ticketsService, IMapper mapper)
        {
            this.ticketsService = ticketsService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TicketResource>), StatusCodes.Status200OK)]
        [Produces("application/json", "application/xml", "text/csv")]
        public async Task<IEnumerable<TicketResource>> GetEvents([FromQuery] TicketQuery query)
        {
            var pagedResult = await ticketsService.GetTickets(query);

            return mapper.Map<IEnumerable<TicketResource>>(pagedResult);
        }
        [HttpDelete]
        public async Task<int> DeleteTicket([FromQuery] int id)
        {
            await ticketsService.DeleteTicket(id);
            return id;
        }
    }
}
