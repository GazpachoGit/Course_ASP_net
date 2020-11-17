using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketService.Core;
using TicketService.DAL.Models;

namespace TicketService.Controllers.api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService cityService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<City>), StatusCodes.Status200OK)]
        [Produces("application/json", "application/xml", "text/csv")]
        public async Task<IEnumerable<City>> GetEvents([FromQuery] string cityName)
        {
            return await cityService.GetCities(cityName);
        }
    }
}
