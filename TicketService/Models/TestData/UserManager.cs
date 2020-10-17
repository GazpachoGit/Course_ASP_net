using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketService.Core;

namespace TicketService.Models
{
    public class UserManager
    {
        //private TestData.TestData testdata;
        private readonly IUserService userService;
        public UserManager(IUserService userService)
        {
            
            this.userService = userService;
            
        }
        //private List<User> userStore;

        public async Task<bool> ValidatePassword(string userName, string password) 
        {
            //var user = userStore.SingleOrDefault(u => u.UserName.ToLower() == userName.ToLower());
            var user = await userService.GetUser(userName);
            if (user != null) 
            {
                return user.Password.Equals(password);
            }
            throw new ArgumentException("User not found");
        }
        public async Task<string> GetRole(string userName) => await userService.GetUserRole(userName);
            //userStore
            //.SingleOrDefault(u => u.UserName.ToLower().Equals(userName.ToLower())).Role;
    }
}
