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
           var _event = await context.Events.FindAsync(Id);
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
        public async Task<bool> CreateEventOk(string eventName, DateTime eventDate, int venueId)
        {
            if (await context.Events.FirstOrDefaultAsync(e => 
            e.Name == eventName &&
            e.Date == eventDate &&
            e.VenueId == venueId) == null) 
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
