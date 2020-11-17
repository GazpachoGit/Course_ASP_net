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
    public class VenueController : ControllerBase
    {
        private readonly IVenueService venueService;
        private readonly IMapper mapper;

        public VenueController(IVenueService venueService, IMapper mapper)
        {
            this.venueService = venueService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VenueResource>), StatusCodes.Status200OK)]
        [Produces("application/json", "application/xml", "text/csv")]
        public async Task<IEnumerable<VenueResource>> GetVenues([FromQuery] VenueQuery venueQuery)
        {
            return mapper.Map<IEnumerable<VenueResource>>(await venueService.GetVenues(venueQuery));
        }
    }
}
