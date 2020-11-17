using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Database;
using TicketService.DAL.Models;
using TicketService.DAL.Models.TestData;

namespace TicketServiceTest
{
    public class CommonServiceTest
    {
        protected CommonServiceTest(DbContextOptions<TicketServiceContext> contextOptions)
        {
           
            ContextOptions = contextOptions;
            Task.Run(() => SeedData()).Wait();

        }
        protected DbContextOptions<TicketServiceContext> ContextOptions { get; }       
        public async Task SeedData()
        {
            using (var contex = new TicketServiceContext(ContextOptions))
            {
                var users = new List<IdentityUser>
                    {
                        new IdentityUser() { UserName = "User1", Id = "1"},
                        new IdentityUser() { UserName = "User2", Id = "2"}
                    };
                var Cities = new List<City>
                {
                    new City {Name = "Москва"},
                    new City {Name = "Волгоград"}
                };
                var Venues = new List<Venue>
                {
                    new Venue { Name = "ДК Пионеров", Address = "Москва", City = Cities[0] },
                    new Venue { Name = "Театр Оперетты", Address = "Москва", City = Cities[1]},
                };
                var Events = new List<Event>()
                {
                    new Event { Date = new DateTime(2020, 07, 28), Name = "Анна Каренина", Venue = Venues[0]},
                    new Event { Date = new DateTime(2019, 06, 27), Name = "Ревизор", Venue = Venues[1] },
                };
                var Tickets = new List<Ticket>()
                {
                    new Ticket { Price = 1000, Event = Events[0], Status = TicketStatus.Selling },
                    new Ticket { Price = 1100, Event = Events[0], Status = TicketStatus.Selling },
                    new Ticket { Price = 1200, Event = Events[1], Status = TicketStatus.Selling },
                    new Ticket { Price = 1300, Event = Events[1], Status = TicketStatus.Selling }
                };

                //Operate
                //await contex.Database.EnsureDeletedAsync();
                await contex.Database.EnsureCreatedAsync();
                
             

                if (! await contex.Events.AnyAsync())
                {
                    await contex.Events.AddRangeAsync(Events);
                }
                if (! await contex.Tickets.AnyAsync())
                {
                    await contex.Tickets.AddRangeAsync(Tickets);
                }
                if (!await contex.Venues.AnyAsync())
                {
                    await contex.Venues.AddRangeAsync(Venues);
                    
                }
                if (!contex.Users.Any())
                {
                    
                    await contex.Users.AddAsync(users[0]);
                    await contex.Users.AddAsync(users[1]);
                }  
                await contex.SaveChangesAsync();
            }
        }
    }
        
}
