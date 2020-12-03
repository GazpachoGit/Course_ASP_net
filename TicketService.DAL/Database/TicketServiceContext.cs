using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketService.DAL.Models;

namespace TicketService.DAL.Database
{
    public class TicketServiceContext : IdentityDbContext
    {
        public TicketServiceContext(DbContextOptions<TicketServiceContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Listing> Listings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Event>().ToTable("Events");
            modelBuilder.Entity<Ticket>().ToTable("Tickets").Property(t => t.ListingId).IsRequired(false);
            //modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<City>().ToTable("Cities");
            modelBuilder.Entity<Venue>().ToTable("Venues");
            modelBuilder.Entity<Listing>().ToTable("Listings");

            //modelBuilder.Entity<Event>().HasKey(e => new { e.EventId });
        }

    }
}
