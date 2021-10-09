using System;
using System.Collections.Generic;
using System.Text;

namespace Polidom.Core.Models
{
    /// <summary>
    /// Represent location update.
    /// </summary>
    public sealed class LocationToUpdate
    {
        /// <summary>
        /// Get or set location's  id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Get or set location's longitude
        /// </summary>
        public string Longitud { get; set; }

        /// <summary>
        /// Get or set location's latitude
        /// </summary>
        public string Latitude { get; set; }
    }
}
