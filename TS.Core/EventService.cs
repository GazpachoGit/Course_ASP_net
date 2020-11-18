using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Database;
using TicketService.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketService.Core.Queries;
using System.Linq.Expressions;

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
        public async Task<bool> EventNotExist(Event _event)
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

        public async Task<bool> EventsExistByVenue(int venueId)
        {
            return await context.Events.Where(e => e.VenueId == venueId).AnyAsync();                        
        }

        public async Task<PagedResult<Event>> GetEvents(EventQuery query)
        {
            var queriable = context.Events.Include(e => e.Venue).ThenInclude(v => v.City).AsQueryable();       

            if (query.Venues?.Any() ?? false)
            {
                queriable = queriable.Where(e => query.Venues.Contains(e.VenueId));
            } else
            {
                if (query.Cities?.Any() ?? false)
                {
                    queriable = queriable.Where(e => query.Cities.Contains(e.Venue.CityId));
                }
            }

            if (!string.IsNullOrEmpty(query.Name))
            {
                if(query.Name.Last() == '*')
                {
                    queriable = queriable.Where(e => e.Name.StartsWith(query.Name.TrimEnd('*')));
                } else
                {
                    queriable = queriable.Where(e => e.Name.Contains(query.Name));
                }               
            }

            if (query.DateFrom != default && query.DateTo != default)
            {
                if (DateTime.Compare(query.DateTo, query.DateFrom) > 0)
                {
                    queriable = queriable.Where(e => e.Date > query.DateFrom && e.Date < query.DateTo);
                }
            } else if (query.DateFrom != default || query.DateFrom != null)
            {
                queriable = queriable.Where(e => e.Date > query.DateFrom);
            } else if (query.DateTo != default || query.DateFrom != null)
            {
                queriable = queriable.Where(e => e.Date < query.DateTo);
            }
            var count = await queriable.CountAsync();

            Expression<Func<Event, object>> sortExpression = query.SortBy switch
            {
                "Name" => e => e.Name,
                "Date" => e => e.Date,
                _ => e => e.Name
            };

            queriable = query.SortOrder switch
            {
                SortOrder.Desc => queriable.OrderByDescending(sortExpression),
                _ => queriable.OrderBy(sortExpression)
            };
            if (query.PageSize <= 0) query.PageSize = 10;
            if (query.Page <= 0) query.Page = 1;
            queriable = queriable.Skip(query.PageSize * (query.Page - 1)).Take(query.PageSize);

           var items = await queriable.ToListAsync();

            return new PagedResult<Event>() { count = count, items = items };
        }

        public async Task<IEnumerable<string>> GetEventNames(string eventName)
        {
            if (!string.IsNullOrEmpty(eventName))
            {
               return context.Events.Where(e => e.Name.Contains(eventName)).Select(e => e.Name).Take(5);
            }
            return new List<string>();
        }
    }
}
