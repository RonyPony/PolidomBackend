using Polidom.Core.Domains;
using Polidom.Core.Enums;
using System;

namespace Polidom.Core.Models
{
    public sealed class ReportToRegister
    {
        public ReportType ReportType { get; set; }
        public int ReporterUserID { get; set; }
        public LocationInfo Ubicacion { get; set; }
        public string Description { get; set; }
    }
}
