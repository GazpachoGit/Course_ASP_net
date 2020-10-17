using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.DAL.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int TicketId { get; set; }
        public string Status { get; set; }
        public string TrackNO { get; set; }
        public Ticket Ticket { get; set; }
        public User Buyer { get; set; }
    }
}
