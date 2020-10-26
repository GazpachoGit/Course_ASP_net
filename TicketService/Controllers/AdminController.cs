using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketService.Core;
using TicketService.DAL.Models;
using TicketService.Models;

namespace TicketService.Controllers
{
    [Authorize(Roles = Roles.Administrator)]

    public class AdminController : Controller
    {
        private readonly IVenueService venueService;
        private readonly ICityService cityService;
        public AdminController(IVenueService venueService, ICityService cityService)
        {
            this.venueService = venueService;
            this.cityService = cityService;
        }
        public async Task<IActionResult> Index()
        {
            if(TempData["DeleteError"] !=null)
            {
                //ModelState.AddModelError("Name", TempData["DeleteError"].ToString());
                ViewBag.Message = "Venue for this city exists";
            }
            ViewBag.Cities = await cityService.GetAllCities();
            ViewBag.Venues = await venueService.GetAllVenues();
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
                
                TempData["DeleteError"] = "Venue exist";
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                await cityService.DeleteCity(cityId);
                return RedirectToAction("Index", "Admin");
            }
        }
    }
}
