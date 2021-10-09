namespace Polidom.Core.Models
{
    /// <summary>
    /// Represents location register.
    /// </summary>
    public sealed class LocationToRegister
    {
        /// <summary>
        /// Get or set location's report id
        /// </summary>
        public int ReportId { get; set; }

        /// <summary>
        /// Get or set location's longitude
        /// </summary>
        public decimal Longitud { get; set; }

        /// <summary>
        /// Get or set location's latitude
        /// </summary>
        public decimal Latitude { get; set; }
    }
}
