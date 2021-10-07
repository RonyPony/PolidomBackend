using Polidom.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Polidom.Core.Domains
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public UserRoleType Role { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime BornDate { get; set; }
    }
}
