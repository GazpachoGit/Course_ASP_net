using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Database;
using TicketService.DAL.Models;

namespace TicketService.Core
{
    public class OrderService : IOrderService
    {
        private readonly TicketServiceContext context;
        public OrderService(TicketServiceContext context)
        {
            this.context = context;
        }
        public async Task CreateOrder(int ticketId, string userId)
        {
            var order = new Order
            {
                TicketId = ticketId,
                BuyerId = userId,
                Status = OrderStatus.Waiting,
                
            };
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }
        public async Task ConfirmOrder(int orderId)
        {
           var order = await context.Orders.FindAsync(orderId);
            order.Status = OrderStatus.Confirmed;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersOnTickets(IEnumerable<Ticket> tickets)
        {
            var idList = tickets.Select(t => t.TicketId);
            return await context.Orders.Where(o => idList.Contains(o.TicketId)).Include(o => o.Ticket).ThenInclude(t => t.Event).Include(o => o.Buyer).ToListAsync();

        }

        public async Task<IEnumerable<Order>> GetOrdersByUsername(string username)
        {
            return await context.Orders.Where(t => t.Buyer.UserName == username).Include(o => o.Ticket).ThenInclude(t => t.Event).ToListAsync();
        }

        public async Task RejectOrder(int orderId)
        {
            var order = await context.Orders.FindAsync(orderId);
            order.Status = OrderStatus.Rejected;
            await context.SaveChangesAsync();
        }
    }
}
