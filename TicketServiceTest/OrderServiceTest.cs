using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TicketService.Core;
using TicketService.DAL.Database;

namespace TicketServiceTest
{
    public class OrderServiceTest : CommonServiceTest
    {
        public OrderServiceTest()
        : base(new DbContextOptionsBuilder<TicketServiceContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ResaleDB_Test;Trusted_Connection=True;")
                    .Options)
        { }
        private TicketServiceContext context;
        private OrderService orderService;

        [SetUp]
        public void Setup()
        {
            context = new TicketServiceContext(ContextOptions);
            orderService = new OrderService(context);
        }

    }
}