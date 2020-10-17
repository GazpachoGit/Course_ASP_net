using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Database;
using TicketService.DAL.Models;

namespace TicketService.Core
{
    public class UserService : IUserService
    {
        private readonly TicketServiceContext context;
        public UserService(TicketServiceContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await context.Users.ToListAsync();
        }
        
    
    }
}
