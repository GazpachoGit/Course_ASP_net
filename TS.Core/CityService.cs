using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Database;
using TicketService.DAL.Models;

namespace TicketService.Core
{
    public class CityService : ICityService
    {
        private readonly TicketServiceContext context;
        public CityService(TicketServiceContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await context.Cities.ToListAsync();
        }
    }
}
