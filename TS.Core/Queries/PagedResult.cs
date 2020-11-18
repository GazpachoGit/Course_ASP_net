using System;
using System.Collections.Generic;
using System.Text;

namespace TicketService.Core.Queries
{
    public class PagedResult<T>
    {
        public int count { get; set; }
        public ICollection<T> items { get; set; }
    }
}
