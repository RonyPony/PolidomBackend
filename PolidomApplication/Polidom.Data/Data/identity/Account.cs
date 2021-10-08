using Microsoft.AspNetCore.Identity;
using Polidom.Core.Enums;
using System;

namespace Polidom.Data.Data.identity
{
    public class Account : IdentityUser
    {
        public string Name { get; set; }
        public UserRoleType Role { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime BornDate { get; set; }
    }
}
