using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketService.Models;

namespace TicketService.Core
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event> GetEvent(int Id);

        Task<int> CreateEvent(Event _event);
        Task EditEvent(int Id);
        Task DeleteEvent(int Id);

    }
}
