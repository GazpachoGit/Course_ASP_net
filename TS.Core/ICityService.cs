using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Models;

namespace TicketService.Core
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllCities();
    }
}
