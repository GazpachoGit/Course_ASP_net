using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Models;

namespace TicketService.Core
{
    public interface ITicketsService
    {
        Task<IEnumerable<Ticket>> GetTicketsByEventId(int eventId);
    }
}
