using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TicketService.DAL.Database;
using TicketService.DAL.Models.TestData;

namespace TicketService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<TicketServiceContext>();
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var testData = new TestData(context, userManager, roleManager);
            await testData.SeedDataAsync();
            await host.RunAsync();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
