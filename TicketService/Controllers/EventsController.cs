using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using TicketService.Core;
using TicketService.DAL.Models;
using TicketService.Models;

namespace TicketService.Controllers
{
    public class EventsController : Controller
    {
        
        private readonly IEventService eventService;
        private readonly IVenueService venueSevice;
        private readonly ICityService cityService;

        public EventsController(IEventService eventService, IVenueService venueSevice, ICityService cityService)
        {
            this.venueSevice = venueSevice;
            this.eventService = eventService;
            this.cityService = cityService;
        }


        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            if (TempData != null && TempData.Count > 0)
            {
                ViewBag.Messages = TempData;
            }
            var Events = await eventService.GetAllEvents();
            return View(Events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {

            var Event = await eventService.GetEventById(id);
            return View(Event);
        }
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateView()
        {
            var venues = await venueSevice.GetAllVenues();
            ViewBag.Venues = new SelectList(venues, "Id", "Name");
            return View();
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditView(int Id)
        {
            var _event = await eventService.GetEventById(Id);
            var venues = await venueSevice.GetAllVenues();
            var selectList = new SelectList(venues, "Id", "Name", _event.VenueId);           
            ViewBag.Venues = selectList;           
            return View(_event);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditEvent(Event _event)
        {
            if (await eventService.EventNotExist(_event))
            {
                await eventService.EditEvent(_event);
                return RedirectToAction("Index", "Events");
            }
            else
            {
                ModelState.AddModelError(nameof(_event.Name), "This event exist");
                return View("EditView");
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateEvent(Event _event)
        {           
            if(await eventService.EventNotExist(_event))
            {
                await eventService.CreateEvent(_event);
                return RedirectToAction("Index", "Events");
            } else
            {
                ModelState.AddModelError(nameof(_event.Name), "This event exist");
                return View("CreateView"); 
            }                       
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await eventService.DeleteEvent(id);
            return RedirectToAction("Index", "Events");
        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
