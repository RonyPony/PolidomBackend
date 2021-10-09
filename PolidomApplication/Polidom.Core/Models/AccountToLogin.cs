using System;
using System.Collections.Generic;
using System.Text;

namespace Polidom.Core.Models
{
    /// <summary>
    /// Represent a account login 
    /// </summary>
    public sealed class AccountToLogin
    {
        /// <summary>
        /// Get or set account's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Get or set account's password
        /// </summary>
        public string Password { get; set; }
    }
}
