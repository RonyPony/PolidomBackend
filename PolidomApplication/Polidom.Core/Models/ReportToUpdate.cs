using Polidom.Core.Domains;
using Polidom.Core.Enums;

namespace Polidom.Core.Models
{
    /// <summary>
    /// Represents update.
    /// </summary>
    public sealed class ReportToUpdate
    {
        /// <summary>
        /// Get or set report's type
        /// </summary>
        public ReportType ReportType { get; set; }

        /// <summary>
        /// Get or set report's user id
        /// </summary>
        public string ReporterUserID { get; set; }

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
