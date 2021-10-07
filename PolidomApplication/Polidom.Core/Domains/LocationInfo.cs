using System.ComponentModel.DataAnnotations;

namespace Polidom.Core.Domains
{
    public class LocationInfo
    {
        [Key]
        public int Id { get; set; }
        public Report Report { get; set; }
        public int ReportId { get; set; }
        public string Longitud { get; set; }
        public string Latitude { get; set; }
    }
}
