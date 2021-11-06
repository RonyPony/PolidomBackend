using Polidom.Core.Enums;
using System;

namespace Polidom.Core.Models
{
    public sealed class AccountToRegister
    {
        /// <summary>
        /// Get or set account's username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Get or set account's complete name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get or set account's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Get or set account's password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Get or set account's phone
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Get or set user's country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Get or set user's location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Get or set user's Province
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// Get or set user's text direction.
        /// </summary>
        public string TextDirection { get; set; }

        /// <summary>
        /// Get or set account's zip code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Get or set user's sector.
        /// </summary>
        public string Sector { get; set; }

        /// <summary>
        /// Get or set account's role
        /// </summary>
        public UserRoleType Role { get; set; }

        /// <summary>
        /// Get or set account's registered date
        /// </summary>
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// Get or set account's born date
        /// </summary>
        public DateTime BornDate { get; set; }
    }
}
