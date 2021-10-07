using Polidom.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Polidom.Core.Domains
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public ReportType ReportType { get; set; }
        public int ReporterUserID { get; set; }
        public DateTime CreationDate { get; set; }
        public LocationInfo Ubicacion { get; set; }
        public string Description { get; set; }
    }
}
