﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketService.Core;
using TicketService.DAL.Models;
using TicketService.Models;

namespace TicketService.Controllers
{
    //Roles = Roles.Administrator
    [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IVenueService venueService;
        private readonly ICityService cityService;
        private readonly IEventService eventService;
        public AdminController(IVenueService venueService, ICityService cityService, UserManager<IdentityUser> userManager, IEventService eventService)
        {
            this.userManager = userManager;
            this.venueService = venueService;
            this.cityService = cityService;
            this.eventService = eventService;
        }
        public async Task<IActionResult> Index()
        {
            if(TempData !=null && TempData.Count > 0)
            {                
                     ViewBag.Messages = TempData;  
            }
            ViewBag.Cities = await cityService.GetAllCities();
            ViewBag.Venues = await venueService.GetAllVenues();
            ViewBag.Users = await userManager.Users.ToListAsync();
            return View();
        }

        public IActionResult CreateCityView()
        {
            return View();
        }
        public async Task<IActionResult> CreateCity(City city)
        {
            await cityService.CreateCity(city);
            return RedirectToAction("Index", "Admin");
        }
        public async Task<IActionResult> EditCityView(int cityId)
        {
            return View(await cityService.GetCityById(cityId));
        }
        public async Task<IActionResult> EditCity(City city)
        {
            await cityService.EditCity(city);
            return RedirectToAction("Index", "Admin");
        }
        public async Task<IActionResult> DeleteCity(int cityId)
        {
            if(await venueService.VenueExistByCity(cityId))
            {
                
                TempData["DeleteCityError"] = "Venue in this city exists";
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                await cityService.DeleteCity(cityId);
                return RedirectToAction("Index", "Admin");
            }
        }
        public async Task<IActionResult> CreateVenueView()
        {
            var cities = await cityService.GetAllCities();
            ViewBag.Cities = new SelectList(cities, "CityId", "Name");
            return View();
        }
        public async Task<IActionResult> CreateVenue(Venue venue)
        {
            await venueService.CreateVenue(venue);
            return RedirectToAction("Index", "Admin");
        }
        public async Task<IActionResult> EditVenueView(int venueId)
        {
            var venue = await venueService.GetVenueById(venueId);
            var cities = await cityService.GetAllCities();
            ViewBag.Cities = new SelectList(cities, "CityId", "Name", venue.CityId);
            return View(venue);
        }
        public async Task<IActionResult> DeleteVenue(int venueId)
        {
            if (await eventService.EventsExistByVenue(venueId))
            {

                TempData["DeleteVenueError"] = "Event for this venue exists";
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                await venueService.DeleteVenue(venueId);
                return RedirectToAction("Index", "Admin");
            }
        }
        public async Task<IActionResult> SetAdminRights(string userId)
        {
            var _user = await userManager.FindByIdAsync(userId);
            if(_user.Id != userManager.GetUserId(User))
            {
                if(await userManager.IsInRoleAsync(_user, "Admin"))
                {
                    await userManager.RemoveFromRoleAsync(_user, "Admin");
                }
                else
                {
                    await userManager.AddToRoleAsync(_user, "Admin");
                }
            } 
            else
            {
                TempData["SetError"] = "Can't manage yourself";
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}
