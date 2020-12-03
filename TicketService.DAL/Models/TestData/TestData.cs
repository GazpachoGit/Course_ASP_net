
using Bogus;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketService.DAL.Database;

namespace TicketService.DAL.Models.TestData
{
    public class TestData
    {

        public TestData(TicketServiceContext contex, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) {
//            InitUsers();
            InitCities();
            InitVenues();
            InitEvents();
            InitTickets();
            this.contex = contex;
            this.userManager = userManager;
            this.roleManager = roleManager;
           


        }
        public List<Event> Events { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Venue> Venues { get; set; }
        public List<City> Cities { get; set; }

        private readonly TicketServiceContext contex;

        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public void InitEvents() {
            var EventFacer = new Faker<Event>()
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
                        .RuleFor(x => x.Price, f => f.Random.Int(500, 10000));

            var tickets = TicketFaker.Generate(20);
            foreach( var item in tickets) 
            {
                item.Event = Events.Random();
            }
            Tickets = tickets;
        }
        public void InitVenues() 
        {
            var VenuesFaker = new Faker<Venue>()
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
                .RuleFor(x => x.Name, f => f.Address.City());
            var cities = CityFaker.Generate(5);
            Cities = cities;
        }
        public async Task SeedDataAsync()
        {
            //await contex.Database.EnsureDeletedAsync();
            await contex.Database.EnsureCreatedAsync();

            if (await roleManager.FindByNameAsync("Admin") == null && await roleManager.FindByNameAsync("User") == null)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                await roleManager.CreateAsync(new IdentityRole { Name = "User" });
            }
            if (!userManager.Users.Any())
            {
                var users = new List<IdentityUser>
                {
                    new IdentityUser() { UserName = "Admin"},
                    new IdentityUser() { UserName = "User"}
                 };
                await userManager.CreateAsync(users[0], "admin");
                await userManager.CreateAsync(users[1], "user");
                await userManager.AddToRoleAsync(users[0], "Admin");
                await userManager.AddToRoleAsync(users[1], "User");
            }

            var Cities = new List<City>
                {
                    new City {Name = "Москва"},
                    new City {Name = "Волгоград"}
                };
            var Venues = new List<Venue>
                {
                    new Venue { Name = "ДК Пионеров", Address = "ул Пушкина", City = Cities[0] },
                    new Venue { Name = "Театр Оперетты", Address = "ул Ленина", City = Cities[1]},
                    new Venue { Name = "Каток Измайлово", Address = "ул Измайлово", City = Cities[1]},
                    new Venue { Name = "Каток пакр Горького", Address = "ул Горького", City = Cities[1]},
                    new Venue { Name = "аквапарк Карибия", Address = "ул Багратиона", City = Cities[1]},
                    new Venue { Name = "банный комплекс Ясенево", Address = "ул Медведково", City = Cities[1]},

                };
            var Events = new List<Event>()
                {
                    new Event { Date = new DateTime(2020, 07, 28), Name = "Анна Каренина", Venue = Venues[1]},
                    new Event { Date = new DateTime(2019, 06, 27), Name = "Ревизор", Venue = Venues[1] },
                    new Event { Date = new DateTime(2020, 12, 08), Name = "Шахматы", Venue = Venues[0] },
                    new Event { Date = new DateTime(2019, 12, 30), Name = "ночное Катание", Venue = Venues[2] },
                    new Event { Date = new DateTime(2019, 12, 27), Name = "дневное Катание", Venue = Venues[3] },
                    new Event { Date = new DateTime(2019, 12, 16), Name = "дневной сеанс бассейн", Venue = Venues[4] },
                    new Event { Date = new DateTime(2019, 12, 04), Name = "ночной сеанс бассейн", Venue = Venues[5] }

                };
            var Listings = new List<Listing>
                {
                    new Listing
                    {
                        ListingName="Аквапарки Москва",
                        ListingDesc="билеты в авквапарки мск на эту зиму",
                        SellerId = userManager.Users.FirstOrDefault((u) => u.UserName == "Admin").Id,
                    },
                    new Listing
                    {
                        ListingName="Катки мск",
                        ListingDesc="билеты на катки в мск",
                        SellerId = userManager.Users.FirstOrDefault((u) => u.UserName == "Admin").Id,
                    }
            };
            var Tickets = new List<Ticket>()
                {
                    new Ticket { Price = 1000, Event = Events[2], Status = TicketStatus.Selling},
                    new Ticket { Price = 1100, Event = Events[0], Status = TicketStatus.Selling},
                    new Ticket { Price = 1200, Event = Events[0], Status = TicketStatus.Selling},
                    new Ticket { Price = 1300, Event = Events[0], Status = TicketStatus.Selling},
                    new Ticket { Price = 1400, Event = Events[1], Status = TicketStatus.Selling},
                    new Ticket { Price = 1500, Event = Events[1], Status = TicketStatus.Selling},
                    new Ticket { Price = 1600, Event = Events[1], Status = TicketStatus.Selling},
                    new Ticket { Price = 700, Event = Events[3], Status = TicketStatus.Selling, ListingId = 1},
                    new Ticket { Price = 800, Event = Events[3], Status = TicketStatus.Selling, ListingId = 1},
                    new Ticket { Price = 900, Event = Events[3], Status = TicketStatus.Selling, ListingId = 1},
                    new Ticket { Price = 1000, Event = Events[4], Status = TicketStatus.Selling, ListingId = 1},
                    new Ticket { Price = 1100, Event = Events[4], Status = TicketStatus.Selling, ListingId = 1},
                    new Ticket { Price = 1200, Event = Events[4], Status = TicketStatus.Selling, ListingId = 1},
                    new Ticket { Price = 200, Event = Events[5], Status = TicketStatus.Selling, ListingId = 2},
                    new Ticket { Price = 300, Event = Events[5], Status = TicketStatus.Selling, ListingId = 2},
                    new Ticket { Price = 400, Event = Events[5], Status = TicketStatus.Selling, ListingId = 2},
                    new Ticket { Price = 500, Event = Events[6], Status = TicketStatus.Selling, ListingId = 2},
                    new Ticket { Price = 600, Event = Events[6], Status = TicketStatus.Selling, ListingId = 2},
                    new Ticket { Price = 700, Event = Events[6], Status = TicketStatus.Selling, ListingId = 2},
                };

            foreach (var item in Tickets)
            {
                item.SellerId = userManager.Users.Random().Id;
            }

            if(!contex.Cities.Any())
            {
                
                await contex.Cities.AddRangeAsync(Cities);
                await contex.SaveChangesAsync();
            }
            if (!contex.Venues.Any())
            {
                await contex.Venues.AddRangeAsync(Venues);
                await contex.SaveChangesAsync();
            }
            if (!contex.Events.Any())
            {
                await contex.Events.AddRangeAsync(Events);
                await contex.SaveChangesAsync();

            }
            if (!contex.Listings.Any())
            {
                await contex.Listings.AddRangeAsync(Listings);
                await contex.SaveChangesAsync();
            };
                
            
            if (!contex.Tickets.Any())
            {
                
                await contex.Tickets.AddRangeAsync(Tickets);
                await contex.SaveChangesAsync();

            }



            await contex.SaveChangesAsync();
        }

    }
}
