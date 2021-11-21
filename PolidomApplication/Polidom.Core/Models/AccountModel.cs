using Newtonsoft.Json;
using System;

namespace Polidom.Core.Models
{
    /// <summary>
    /// Represent the account model.
    /// </summary>
    public sealed class AccountModel
    {
        /// <summary>
        /// Get or set account's id
        /// </summary>
        [JsonProperty("id")]
        public string id { get; set; }
        /// <summary>
        /// Get or set account's email
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Get or set account's username
        /// </summary>
        [JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// Get or set account's complete name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Get or set account's phone number
        /// </summary>
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Get or set account's role
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; }

        /// <summary>
        /// Get or set account's registered date
        /// </summary>
        [JsonProperty("registerDate")]
        public DateTime RegisteredDate { get; set; }
    }
}
