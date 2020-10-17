using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketService.Database;
using TicketService.Models;
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

        public Task EditEvent(int EventId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await context.Events.Include(e => e.Venue).ThenInclude(v => v.City).ToListAsync();
        }

        public async Task<Event> GetEvent(int Id)
        {
            return await context.Events.Include(e => e.Venue).ThenInclude(v => v.City).SingleOrDefaultAsync(e => e.EventId == Id);
        }
    }
}
