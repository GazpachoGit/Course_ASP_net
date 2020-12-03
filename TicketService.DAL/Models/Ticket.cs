using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.DAL.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public TicketStatus Status { get; set; }
        public int EventId { get; set; }
        public decimal Price { get; set; }
        public string SellerId { get; set; }
        public IdentityUser Seller { get; set; }
        public Event Event { get; set; }
        public int? ListingId { get; set; }
        public Listing Listing { get; set; }
    }
}
