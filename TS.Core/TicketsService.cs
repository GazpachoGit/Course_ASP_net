using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Database;
using TicketService.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace TicketService.Core
{
    public class TicketsService : ITicketsService
    {
        private readonly TicketServiceContext context;
        public TicketsService(TicketServiceContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Ticket>> GetTicketsByEventId(int eventId)
        {
            
            return await context.Tickets.Where(t => t.Event.EventId == eventId).Include(t => t.Event).Include(t => t.Seller).ToListAsync();
       }
        public async Task<int> CreateTicket(Ticket ticket)
        {
            await context.Tickets.AddAsync(ticket);
            await context.SaveChangesAsync();
            return ticket.EventId;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUsername(string userName)
        {
            return await context.Tickets.Where(t => t.Seller.UserName == userName).Include(t => t.Event).ThenInclude(e => e.Venue).ToListAsync();
        }

        public async Task<int> BuyTicket(int ticketId)
        {
           var ticket = await context.Tickets.SingleOrDefaultAsync(t => t.TicketId == ticketId);
           ticket.Status = TicketStatus.Waiting;
           await context.SaveChangesAsync();
            return ticketId;

        }

        public async Task<IEnumerable<Ticket>> GetTicketsAvailableByEventId(int eventId)
        {
            return await context.Tickets.Where(t => t.Event.EventId == eventId).Where(t => t.Status == TicketStatus.Selling || t.Status == TicketStatus.Waiting).Include(t => t.Event).Include(t => t.Seller).ToListAsync();
        }

        public async Task<int> ApproveTicket(int ticketId)
        {
            var ticket = await context.Tickets.FindAsync(ticketId);
            ticket.Status = TicketStatus.Sold;
            await context.SaveChangesAsync();
            return ticketId;
        }

        public async Task RejectTicket(int ticketId)
        {
            var ticket = await context.Tickets.FindAsync(ticketId);
            ticket.Status = TicketStatus.Selling;
            await context.SaveChangesAsync();
        }
        public async Task<bool> TicketOrderExist(int ticketId)
        {
            return await context.Orders.Where(o => o.TicketId == ticketId && o.Status == OrderStatus.Waiting).AnyAsync();
        }

        public async Task<Ticket> GetTicket(int ticketId)
        {
            return await context.Tickets.FindAsync(ticketId);
        }
    }
}
