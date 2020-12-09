using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketService.Core.Queries;
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
        Task RejectTicket(int ticketId);
        Task<bool> TicketOrderExist(int ticketId);
        Task<Ticket> GetTicket(int ticketId);
        Task<IEnumerable<Ticket>> GetTickets(TicketQuery query);
        Task<int> DeleteTicket(int id);
    }
}
