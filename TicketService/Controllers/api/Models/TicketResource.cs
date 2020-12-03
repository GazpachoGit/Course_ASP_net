using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketService.DAL.Models;

namespace TicketService.Controllers.api.Models
{
    public class TicketResource
    {
        public int id { get; set; }
        public TicketStatus Status { get; set; }
        public int EventId { get; set; }
        public decimal Price { get; set; }
        public string SellerId { get; set; }
        public string EventName { get; set; }
        public string VenueName { get; set; }
        public string Date { get; set; }
        public int? ListingId { get; set; }
        public string CityName { get; set; }

    }
}
