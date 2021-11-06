using Polidom.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Polidom.Core.Domains
{
    /// <summary>
    /// Represent a report domain.
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Get or set report's id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Get or set report's type
        /// </summary>
        public ReportType ReportType { get; set; }

        /// <summary>
        /// Get or set Report's user id.
        /// </summary>
        public int ReporterUserId { get; set; }

        /// <summary>
        /// Get or set Report's assigned authority id.
        /// </summary>
        public bool AssignedAuthorityId { get; set; }

        /// <summary>
        /// Get or set report's register date.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Get or set locations's info
        /// </summary>
        public LocationInfo Ubicacion { get; set; }

        /// <summary>
        /// Get or set Report's description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Get or set Report's completed.
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Get or set Report's deleted
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
