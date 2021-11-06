using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "decimal(18,7)")]
        public decimal Longitude { get; set; }

        /// <summary>
        /// Get or set location's latitude
        /// </summary>
        [Column(TypeName = "decimal(18,7)")]
        public decimal Latitude { get; set; }
        
        /// <summary>
        /// Get or set location's country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Get or set location's locality
        /// </summary>
        public string Locality { get; set; }

        /// <summary>
        /// Get or set location's province.
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// Get or set location's sector
        /// </summary>
        public string Sector { get; set; }

        /// <summary>
        /// Get or set location's direction
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// Get or set location's zip code.
        /// </summary>
        public string ZipCode { get; set; }
    }
}
