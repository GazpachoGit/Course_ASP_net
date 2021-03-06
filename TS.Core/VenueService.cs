﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Core.Queries;
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
            return await context.Venues.Include(v => v.City).ToListAsync();
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

        public async Task DeleteVenue(int venueId)
        {
            context.Venues.Remove(await context.Venues.FindAsync(venueId));
            await context.SaveChangesAsync();
        }

        public async Task<object> GetVenues(VenueQuery query)
        {
            var queriable = context.Venues.AsQueryable();
            if (!string.IsNullOrEmpty(query.venueName))
            {
                queriable = queriable.Where(e => e.Name.Contains(query.venueName));
            }
            if (query.Cities?.Any() ?? false)
            {
                queriable = queriable.Where(v => query.Cities.Contains(v.CityId));
            }
            return await queriable.ToListAsync();
        }
    }
}
