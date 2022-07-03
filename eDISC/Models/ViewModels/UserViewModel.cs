using System;
using System.Collections.Generic;

namespace eDISC.Models.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public List<UserType> UserTypes { get; set; }
    }
}
