using Polidom.Core.Enums;
using System;

namespace Polidom.Core.Models
{
    public sealed class AccountToRegister
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public UserRoleType Role { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime BornDate { get; set; }
    }
}
