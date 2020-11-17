using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TicketService.DAL.Database;
using TicketService.Core;
using System.Threading.Tasks;
using System.Linq;
using TicketService.DAL.Models;
using System;

namespace TicketServiceTest
{
    public class EventServiceTest : CommonServiceTest
    {
        public EventServiceTest()
        : base(new DbContextOptionsBuilder<TicketServiceContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ResaleDB_Test;Trusted_Connection=True;")
                    .Options)
        { }

        private TicketServiceContext context;
        private EventService eventService;

        [SetUp]
        public void Setup()
        {
            context = new TicketServiceContext(ContextOptions);
            eventService = new EventService(context);
        }

        [Test]
        public async Task Can_get_AllEvents()
        {
            var items = await eventService.GetAllEvents();
            Assert.That(2, Is.EqualTo(items.Count()));
        }
        [Test]
        public async Task Check_Event_Not_Exists_By_Name()
        {
            var ExistingEvent = await eventService.GetEventById(1);
            var EventExist = await eventService.EventNotExist(ExistingEvent);
            Assert.That(false, Is.EqualTo(EventExist));

            var NotExistingEvent1 = ExistingEvent;
            NotExistingEvent1.Name = "Not Анна Каренина";
            var Event1NotExist = await eventService.EventNotExist(NotExistingEvent1);
            Assert.That(true, Is.EqualTo(Event1NotExist));
        }
        [Test]
        public async Task Check_Event_Not_Exists_By_Date()
        {
            var ExistingEvent = await eventService.GetEventById(1);
            var NotExistingEvent2 = ExistingEvent;
            NotExistingEvent2.Date = new DateTime(2018, 05, 26);
            var Event2NotExist = await eventService.EventNotExist(NotExistingEvent2);
            Assert.That(true, Is.EqualTo(Event2NotExist));
        }
        [Test]
        public async Task Check_Event_Not_Exists_By_Venue()
        {
            var ExistingEvent = await eventService.GetEventById(1);
            var venues = context.Venues.ToList();
            var NotExistingEvent3 = ExistingEvent;
            NotExistingEvent3.VenueId = venues[1].Id;
            var Event3NotExist = await eventService.EventNotExist(NotExistingEvent3);
            
            Assert.That(true, Is.EqualTo(Event3NotExist));
        }
    }
}