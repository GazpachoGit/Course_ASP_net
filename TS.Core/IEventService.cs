using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketService.DAL.Models;

namespace TicketService.Core
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetEventById(int Id);
        Task<Event> GetEventByIdWithTickets(int Id);

        Task<int> CreateEvent(Event _event);
        Task EditEvent(Event _event);
        Task DeleteEvent(int Id);
        Task<bool> CreateEventOk(Event _event);

    }
}
