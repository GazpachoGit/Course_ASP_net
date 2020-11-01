using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Models;

namespace TicketService.Core
{
    public interface IOrderService
    {
        Task CreateOrder(int ticketId, string userId);
        Task<IEnumerable<Order>>  GetOrdersOnTickets(IEnumerable<Ticket> tickets);
        Task ConfirmOrder(int orderId);
        Task<IEnumerable<Order>> GetOrdersByUsername(string username);
        Task RejectOrder(int orderId);
    }
}
