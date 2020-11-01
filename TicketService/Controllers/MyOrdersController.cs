using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TicketService.Core;

namespace TicketService.Controllers
{
    public class MyOrdersController : Controller
    {
        private readonly ITicketsService ticketsService;
        private readonly IOrderService orderService;
        private readonly UserManager<IdentityUser> userService;

        public MyOrdersController(ITicketsService ticketsService, IOrderService orderService, UserManager<IdentityUser> userService)
        {
            this.orderService = orderService;
            this.ticketsService = ticketsService;
            this.userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var username = User.Identity.Name;
            var orders = await orderService.GetOrdersByUsername(username);
            return View(orders);
        }
    }
}
