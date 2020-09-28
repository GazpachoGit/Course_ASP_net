using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TicketService.Models
{
    public class UserManager
    {
        private TestData.TestData testdata;
        public UserManager(TestData.TestData testdata)
        {
            this.testdata = testdata;
            this.userStore = testdata.Users;
            
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
