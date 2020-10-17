using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Database;
using TicketService.Models;
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
        public async Task<IEnumerable<Ticket>> GetTicketsByEvent(int eventId)
        {
            return await context.Tickets.Where(t => t.Event.EventId == eventId).Include(t => t.Event).Include(t => t.Seller).ToListAsync();
        }
    }
}
