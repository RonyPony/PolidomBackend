using Microsoft.AspNetCore.Identity;
using Polidom.Core.Enums;
using System;

namespace Polidom.Data.Data.identity
{
    /// <summary>
    /// Represent the account identity
    /// </summary>
    public class Account : IdentityUser
    {
        /// <summary>
        /// Get or set user's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get or set account's role
        /// </summary>
        public UserRoleType Role { get; set; }

        /// <summary>
        /// Get or set account's registered date.
        /// </summary>
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// Get or set user's born date
        /// </summary>
        public DateTime BornDate { get; set; }
    }
}
