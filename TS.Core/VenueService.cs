using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Database;
using TicketService.DAL.Models;

namespace TicketService.Core
{
    public class VenueService : IVenueService
    {
        private readonly TicketServiceContext context;

        public VenueService(TicketServiceContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Venue>> GetAllVenues()
        {
            return await context.Venues.ToListAsync();
        }

        public async Task<int> GetVenueIdByName(string VenueName)
        {
            var venue = await context.Venues.FirstOrDefaultAsync(v => v.Name == VenueName);
            return venue.Id;
        }

    }
}
