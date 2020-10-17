using System;

namespace TicketService.Core
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAll();
    }
}
