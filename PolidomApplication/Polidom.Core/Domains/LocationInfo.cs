using System.ComponentModel.DataAnnotations;

namespace Polidom.Core.Domains
{
    /// <summary>
    /// Represent a location info domain.
    /// </summary>
    public class LocationInfo
    {
        /// <summary>
        /// Get or set location's id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Get or set report's domain.
        /// </summary>
        public Report Report { get; set; }

        /// <summary>
        /// Get or set report's id.
        /// </summary>
        public int ReportId { get; set; }

        /// <summary>
        /// Get or set location's longitud.
        /// </summary>
        public string Longitud { get; set; }

        /// <summary>
        /// Get or set location's latitude
        /// </summary>
        public string Latitude { get; set; }
    }
}
