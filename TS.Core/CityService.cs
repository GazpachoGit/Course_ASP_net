using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Database;
using TicketService.DAL.Models;

namespace TicketService.Core
{
    public class CityService : ICityService
    {
        private readonly TicketServiceContext context;
        public CityService(TicketServiceContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await context.Cities.ToListAsync();
        }

        public async Task<int> CreateCity(City city)
        {
            await context.Cities.AddAsync(city);
            await context.SaveChangesAsync();
            return city.CityId;
        }
        public async Task<int> EditCity(City city)
        {
            context.Cities.Update(city);
            await context.SaveChangesAsync();
            return city.CityId;
        }

        public async Task DeleteCity(int Id)
        {
            var city = await context.Cities.FindAsync(Id);
            context.Cities.Remove(city);
            await context.SaveChangesAsync();
        }

        public async Task<City> GetCityById(int cityId)
        {
            return await context.Cities.FindAsync(cityId);
            
        }

        public async Task<IEnumerable<City>> GetCities(string cityName)
        {
            var queriable = context.Cities.AsQueryable();
            if (!string.IsNullOrEmpty(cityName))
            {
                queriable = queriable.Where(c => c.Name.Contains(cityName));
            }
            return await queriable.ToListAsync();
        }
    }
}
