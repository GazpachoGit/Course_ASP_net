using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Models;

namespace TicketService.Core
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(string userName);
        Task<string> GetUserRole(string userName);
    }
    
}
