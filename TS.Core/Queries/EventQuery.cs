using System;
using System.Collections.Generic;
using System.Text;

namespace TicketService.Core.Queries
{
    public class EventQuery
    {
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int[] Cities { get; set; }
        public int[] Venues { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public SortOrder SortOrder { get; set; }


    }
}
