using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
            var Events = await eventService.GetAllEvents();
            return View(Events);
        }

       [Route("Events/{id}")]
        public async Task<IActionResult> Details(int id)
        {

            var Event = await eventService.GetEventById(id);
            return View(Event);
        }

        public async Task<IActionResult> CreateView()
        {
            var venues = await venueSevice.GetAllVenues();
            ViewBag.Venues = new SelectList(venues, "Id", "Name");
            return View();
        }
        public async Task<IActionResult> EditView(int Id)
        {
            var _event = await eventService.GetEventById(Id);
            var eventModel = new EventViewModel()
            {
                Id = _event.EventId,
                Name = _event.Name,
                Date = _event.Date,
                VenueId = _event.VenueId
            };
            var venues = await venueSevice.GetAllVenues();
            var selectList = new SelectList(venues, "Id", "Name", _event.VenueId);           
            ViewBag.Venues = selectList;           
            return View(eventModel);
        }
        public async Task<IActionResult> EditEvent(EventViewModel eventModel)
        {
            if (await eventService.CreateEventOk(eventModel.Name, eventModel.Date, eventModel.VenueId))
            {
                var _newEvent = new Event
                {
                    EventId = eventModel.Id,
                    Name = eventModel.Name,
                    Date = eventModel.Date,
                    VenueId = eventModel.VenueId
                };
                await eventService.EditEvent(_newEvent);
                return RedirectToAction("Index", "Events");
            }
            else
            {
                ModelState.AddModelError(nameof(eventModel.Name), "This event exist");
                return View("EditView");
            }
        }
        public async Task<IActionResult> CreateEvent(EventViewModel eventModel)
        {
            
            if(await eventService.CreateEventOk(eventModel.Name, eventModel.Date, eventModel.VenueId))
            {
                var newEvent = new Event()
                {
                    Name = eventModel.Name,
                    Date = eventModel.Date,
                    VenueId = eventModel.VenueId
                };
                await eventService.CreateEvent(newEvent);
                return RedirectToAction("Index", "Events");
            } else
            {
                ModelState.AddModelError(nameof(eventModel.Name), "This event exist");
                return View("CreateView"); 
            }
            
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
