using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Database;
using TicketService.DAL.Models;

namespace TicketService.Core
{
    public class ListingService : IListingService
    {
        private readonly TicketServiceContext context;

        public ListingService(TicketServiceContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Listing>> GetAllByUser(string userName)
        {
            return await context.Listings.Where(l => l.Seller.UserName == userName).ToListAsync();
        }
    }
}
