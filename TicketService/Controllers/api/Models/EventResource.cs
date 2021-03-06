﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketService.DAL.Models;

namespace TicketService.Controllers.api.Models
{
    public class EventResource
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int VenueId { get; set; }

        public string Banner { get; set; }
        public string Description { get; set; }

        public Venue Venue { get; set; }
        public string CityName { get; set; }
    }
}
