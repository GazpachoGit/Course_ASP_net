using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketService.DAL.Database;

namespace TicketService.DAL.Models
{
    public class UserManager
    {
        //private TestData.TestData testdata;
        private readonly TicketServiceContext context;
        public UserManager(TicketServiceContext context)
        {
            this.context = context;
            this.userStore = context.Users.ToList();
            
        }
        private List<User> userStore;

        public bool ValidatePassword(string userName, string password) 
        {
            var user = userStore.SingleOrDefault(u => u.UserName.ToLower() == userName.ToLower());
            if (user != null) 
            {
                return user.Password.Equals(password);
            }
            throw new ArgumentException("User not found");
        }
        public string GetRole(string userName) => userStore
            .SingleOrDefault(u => u.UserName.ToLower().Equals(userName.ToLower())).Role;
    }
}
