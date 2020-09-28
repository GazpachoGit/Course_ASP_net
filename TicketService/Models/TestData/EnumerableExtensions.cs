using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.Models.TestData
{
    public static class EnumerableExtensions
    {
        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            var r = new Random();
            var list = enumerable as IList<T> ?? enumerable.ToList();
            return list.ElementAt(r.Next(list.Count()));
        }
    }
}
