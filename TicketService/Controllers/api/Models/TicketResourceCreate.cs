using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.Controllers.api.Models
{
    public class TicketResourceCreate
    {
        public int EventId { get; set; }
        public decimal Price { get; set; }

        public int? ListingId { get; set; }
    }
}
