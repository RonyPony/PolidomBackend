using Polidom.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polidom.Core.Models
{
    public class AccountToRegister
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRoleType Role { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime BornDate { get; set; }
    }
}
