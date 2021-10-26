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

        /// Get or set user's zipCode
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Get or set user's text direction.
        /// </summary>
        public string TextDirection { get; set; }

        /// <summary>
        /// Get or set user's country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Get or set user's province
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// Get or set user's location
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Get or set user's sector
        /// </summary>
        public string Sector { get; set; }

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
