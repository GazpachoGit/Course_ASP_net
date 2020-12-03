using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Models;

namespace TicketService.Core
{
    public interface IListingService
    {
        Task<IEnumerable<Listing>> GetAllByUser(string userName);
    }
}
