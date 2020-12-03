using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketService.DAL.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string ListingName { get; set; }
        public string ListingDesc { get; set; }
        public ICollection<Ticket> ListingBody { get; set; }
        public string SellerId { get; set; }
        public IdentityUser Seller { get; set; }
    }
}
