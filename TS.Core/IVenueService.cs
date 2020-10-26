using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Models;

namespace TicketService.Core
{
    public interface IVenueService
    {
        Task<int> GetVenueIdByName(string VenueName);
        Task<IEnumerable<Venue>> GetAllVenues();
        Task<int> CreateVenue(Venue venue);
        Task<IEnumerable<Venue>> GetVenuesByCity(int cityId);
        Task<bool> VenueExistByCity(int cityId);
    }
}
