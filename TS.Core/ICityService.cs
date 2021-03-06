﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Models;

namespace TicketService.Core
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllCities();
        Task<City> GetCityById(int Id);
        Task<int> CreateCity(City city);
        Task<int> EditCity(City city);
        Task DeleteCity(int cityId);
        Task<IEnumerable<City>> GetCities(string cityName);
    }
}
