using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketService.Models;

namespace TicketService.Core
{
    public interface ITicketsService
    {
        Task<IEnumerable<Ticket>> GetTicketsByEvent(int eventId);
    }
}
