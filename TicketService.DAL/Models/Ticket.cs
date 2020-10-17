using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.DAL.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int EventId { get; set; }
        public decimal Price { get; set; }
        public User Seller { get; set; }
        public Event Event { get; set; }
    }
}
