using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.Models
{
    public class EventViewModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int VenueId { get; set; }

        public string Banner { get; set; }
        public string Description { get; set; }

    }
}
