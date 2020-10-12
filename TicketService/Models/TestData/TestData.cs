
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.Models.TestData
{
    public class TestData
    {

        public TestData() {
            InitUsers();
            InitCities();
            InitVenues();
            InitEvents();
            InitTickets();
           


        }
        public List<Event> Events { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Venue> Venues { get; set; }
        public List<City> Cities { get; set; }
        public List<User> Users { get; set; }

        public void InitEvents() {
            var EventFacer = new Faker<Event>()
            .RuleFor(x => x.Id, f => f.IndexGlobal)
            .RuleFor(x => x.Name, f => f.Commerce.Product())
            .RuleFor(x => x.Date, f => f.Date.Past());
            

            var events = EventFacer.Generate(5);
            foreach (var item in events)
            {                
                item.Venue = Venues.Random();
                item.Description = $"<p>Описание представления <b>{item.Name}</b>," +
                    $" которое пройдет <i> {item.Date:yyyy - MM - dd:HH:mm}</i></p>";
            }
            
            Events = events;
        }        
        public void InitTickets()  {

            var TicketFaker = new Faker<Ticket>()
                        .RuleFor(x => x.Id, f => f.IndexGlobal)
                        .RuleFor(x => x.Price, f => f.Random.Int(500, 10000));
                        

            var tickets = TicketFaker.Generate(20);
            foreach( var item in tickets) 
            {
                item.Seller = Users.Random();
                item.Event = Events.Random();
            }
            Tickets = tickets;
        }
        public void InitVenues() 
        {
            var VenuesFaker = new Faker<Venue>()
                .RuleFor(x => x.Id, f => f.IndexGlobal)
                .RuleFor(x => x.Name, f => f.Company.CompanyName())                
                .RuleFor(x => x.Address, f => f.Address.StreetAddress());
            var venues = VenuesFaker.Generate(5);
            foreach (var item in venues)
            {
                item.City = Cities.Random();
            }
            Venues = venues;

        }

        public void InitCities() 
        {
            var CityFaker = new Faker<City>()
                .RuleFor(x => x.Id, f => f.IndexGlobal)
                .RuleFor(x => x.Name, f => f.Address.City());
            var cities = CityFaker.Generate(5);
            Cities = cities;
        }
        public void InitUsers() 
        {
            Users = new List<User>()
            {
                new User() { FirstName ="Jonh", LastName = "Doe", Address = "Пушкина дом Колотушкина", Localization = "Moscow", Id= 2,
                UserName = "user", Password = "user", Role = Roles.User},
                new User() { FirstName ="Egor", LastName = "Tornikov", Address = "Пушкина дом Колотушкина", Localization = "Vladivostok", Id= 1,
                UserName = "Admin", Password = "admin", Role = Roles.Administrator}
            };
        }

    }
}
