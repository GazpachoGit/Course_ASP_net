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
        public async Task<int> CreateVenue(Venue venue)
        {
            await context.Venues.AddAsync(venue);
            await context.SaveChangesAsync();
            return venue.Id;
        }
        public async Task<IEnumerable<Venue>> GetVenuesByCity(int cityId)
        {
            return await context.Venues.Where(v => v.CityId == cityId).ToListAsync();
        }
        public async Task<bool> VenueExistByCity(int cityId)
        {
            return await context.Venues.Where(v => v.CityId == cityId).AnyAsync();
        }

        public async Task<Venue> GetVenueById(int venueId)
        {
            return await context.Venues.FindAsync(venueId);

        }
    }
}
