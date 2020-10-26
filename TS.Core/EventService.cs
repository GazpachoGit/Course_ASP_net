using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Database;
using TicketService.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TicketService.Core
{
    public class EventService : IEventService
    {
        private readonly TicketServiceContext context;

        public EventService(TicketServiceContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateEvent(Event _event)
        {
            await context.Events.AddAsync(_event);
            await context.SaveChangesAsync();
            return _event.EventId;
        }

        public async Task DeleteEvent(int Id)
        {
            var _event = await context.Events.Include(e => e.Tickets).SingleOrDefaultAsync(e => e.EventId .Equals(Id));
            context.Events.Remove(_event);
            await context.SaveChangesAsync();
        }

        public async Task EditEvent(Event _event)
        {
            context.Events.Update(_event);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await context.Events.Include(e => e.Venue).ThenInclude(v => v.City).ToListAsync();
        }

        public async Task<Event> GetEventById(int Id)
        {
            return await context.Events.Include(e => e.Venue).ThenInclude(v => v.City).SingleOrDefaultAsync(e => e.EventId == Id);
        }
        public async Task<Event> GetEventByIdWithTickets(int Id)
        {
            return await context.Events.Include(e => e.Venue).ThenInclude(v => v.City).Include(e => e.Tickets).SingleOrDefaultAsync(e => e.EventId == Id);
        }
        public async Task<bool> CreateEventOk(Event _event)
        {
            if (await context.Events.FirstOrDefaultAsync(e => 
            e.Name == _event.Name &&
            e.Date == _event.Date &&
            e.VenueId == _event.VenueId) == null) 
            {
                return true;
            } 
            else
            {
                return false;
            }
        }
    }
}
