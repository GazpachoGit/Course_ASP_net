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
    }
}
