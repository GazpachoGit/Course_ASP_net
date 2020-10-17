﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Localization { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }


    }
}