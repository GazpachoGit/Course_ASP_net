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
        Task<IEnumerable<Ticket>> GetTicketsAvailableByEventId(int eventId);
        Task<int> CreateTicket(Ticket ticket);
        Task<IEnumerable<Ticket>> GetTicketsByUsername(string userName);
        Task<int> BuyTicket(int ticketId);
        Task<int> ApproveTicket(int ticketId); 
    }
}
