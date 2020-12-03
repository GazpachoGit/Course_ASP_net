using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketService.Controllers.api.Models;
using TicketService.Core;

namespace TicketService.Controllers.api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly IListingService listingService;
        private readonly IMapper mapper;
        public ListingController(IListingService listingService, IMapper mapper)
        {
            this.listingService = listingService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ListingResource>), StatusCodes.Status200OK)]
        [Produces("application/json", "application/xml", "text/csv")]
        public async Task<IEnumerable<ListingResource>> GetListings([FromHeader] string userName)
        {
            var listings = await listingService.GetAllByUser(userName);
            return mapper.Map<IEnumerable<ListingResource>>(listings);
            
        }
    }
}
