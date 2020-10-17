using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketService.Models;

namespace TicketService.Database
{
    public class TicketServiceContext : DbContext
    {
        public TicketServiceContext(DbContextOptions<TicketServiceContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().ToTable("Events");
            modelBuilder.Entity<Ticket>().ToTable("Tickets");
            //modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<City>().ToTable("Cities");
            modelBuilder.Entity<Venue>().ToTable("Venues");

            //modelBuilder.Entity<Event>().HasKey(e => new { e.EventId });
        }

    }
}
