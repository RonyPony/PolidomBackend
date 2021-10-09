using Polidom.Core.Domains;
using Polidom.Core.Enums;
using System;

namespace Polidom.Core.Models
{
    /// <summary>
    /// Represent report register
    /// </summary>
    public sealed class ReportToRegister
    {
        /// <summary>
        /// Get or set report's type
        /// </summary>
        public ReportType ReportType { get; set; }

        /// <summary>
        /// Get or set report's user id
        /// </summary>
        public int ReporterUserID { get; set; }

        /// <summary>
        /// Get or set report's ubication
        /// </summary>
        public LocationInfo Ubicacion { get; set; }

        /// <summary>
        /// Get or set report's description
        /// </summary>
        public string Description { get; set; }
    }
}
