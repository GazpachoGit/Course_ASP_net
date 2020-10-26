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
    public class UserService : IUserService
    {
        private readonly DbSet<User> Users;
        public UserService(TicketServiceContext context)
        {
            this.Users = context.Users;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersNames()
        {
            return await Users.Select(u => new User { UserName = u.UserName, Id = u.Id }).ToListAsync();
        }

        public async Task<User> GetUser(string userName)
        {
            return await Users.SingleOrDefaultAsync(u => u.UserName.ToLower() == userName.ToLower());
        }

        public async Task<string> GetUserRole(string userName)
        {
            var user = await Users.SingleOrDefaultAsync(u => u.UserName.ToLower().Equals(userName.ToLower()));
            return user.Role;
        }
    }
}
