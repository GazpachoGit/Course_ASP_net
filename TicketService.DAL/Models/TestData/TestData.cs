
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
 //       public List<User> Users { get; set; }

        private readonly TicketServiceContext contex;

        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public void InitEvents() {
            var EventFacer = new Faker<Event>()
            //.RuleFor(x => x.EventId, f => f.IndexGlobal)
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
                        //.RuleFor(x => x.TicketId, f => f.IndexGlobal)
                        .RuleFor(x => x.Price, f => f.Random.Int(500, 10000));
                        

            var tickets = TicketFaker.Generate(20);
            foreach( var item in tickets) 
            {
                //item.Seller = Users.Random();
                item.Event = Events.Random();
            }
            Tickets = tickets;
        }
        public void InitVenues() 
        {
            var VenuesFaker = new Faker<Venue>()
                //.RuleFor(x => x.Id, f => f.IndexGlobal)
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
                //.RuleFor(x => x.CityId, f => f.IndexGlobal)
                .RuleFor(x => x.Name, f => f.Address.City());
            var cities = CityFaker.Generate(5);
            Cities = cities;
        }
/*        public async Task InitUsers() 
        {
            if (!userManager.Users.Any())
            {
               
            }

*//*                Users = new List<User>()
            {
                new User() { FirstName ="Jonh", LastName = "Doe", Address = "Пушкина 3 дом Колотушкина 4", Localization = "Moscow", 
                UserName = "user", Password = "user", Role = Roles.User},
                new User() { FirstName ="Egor", LastName = "Tornikov", Address = "Пушкина 1 дом Колотушкина 2", Localization = "Vladivostok", 
                UserName = "Admin", Password = "admin", Role = Roles.Administrator}
            };*//*
        }*/

        public async Task SeedDataAsync()
        {
            await contex.Database.EnsureCreatedAsync();

            if (await roleManager.FindByNameAsync("Admin") == null && await roleManager.FindByNameAsync("User") == null)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                await roleManager.CreateAsync(new IdentityRole { Name = "User" });
            }

            //var user1 = new IdentityUser() { UserName = "Admin"};
            //var user2 = new IdentityUser() { UserName = "User"};
            //await userManager.CreateAsync(user1, "admin123");
            //await userManager.CreateAsync(user2, "user");
            var user1 = await userManager.FindByNameAsync("user");
            await userManager.AddToRoleAsync(user1, "User");
            //await userManager.AddToRoleAsync(user2, "User");

            if (!contex.Events.Any())
            {
                await contex.Events.AddRangeAsync(Events);

            }
            if (!contex.Tickets.Any())
            {
                await contex.Tickets.AddRangeAsync(Tickets);

            }
/*            if (!contex.Users.Any())
            {
                await contex.Users.AddRangeAsync(Users);

            }*/
            if (!contex.Venues.Any())
            {
                await contex.Venues.AddRangeAsync(Venues);

            }

            await contex.SaveChangesAsync();
        }

    }
}
