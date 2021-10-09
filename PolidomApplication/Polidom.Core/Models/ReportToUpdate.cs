using Polidom.Core.Domains;
using Polidom.Core.Enums;

namespace Polidom.Core.Models
{
    public sealed class ReportToUpdate
    {
        public ReportType ReportType { get; set; }
        public int ReporterUserID { get; set; }
        public LocationInfo Ubicacion { get; set; }
        public string Description { get; set; }
    }
}
