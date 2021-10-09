using System;

namespace Polidom.Core.Models
{
    /// <summary>
    /// Represent the account model.
    /// </summary>
    public sealed class AccountModel
    {
        /// <summary>
        /// Get or set account's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Get or set account's username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Get or set account's complete name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get or set account's phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Get or set account's role
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Get or set account's registered date
        /// </summary>
        public DateTime RegisteredDate { get; set; }
    }
}
