using System;
using System.Collections.Generic;
using System.Text;

namespace TicketService.Core.Queries
{
    public class TicketQuery
    {
        public int? ListingId { get; set; }
        public string eventName { get; set; }
        public string cityName { get; set; }       
    }
}
