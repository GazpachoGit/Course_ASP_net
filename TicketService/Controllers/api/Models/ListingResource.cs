using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.Controllers.api.Models
{
    public class ListingResource
    {
        public int Id { get; set; }
        public string ListingName { get; set; }
        public string ListingDesc { get; set; }
        public string SellerId { get; set; }
    }
}
