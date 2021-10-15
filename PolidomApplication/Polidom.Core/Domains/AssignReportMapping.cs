using System.ComponentModel.DataAnnotations;

namespace Polidom.Core.Domains
{
    public class AssignReportMapping
    {
        [Key]
        public int Id { get; set; }
        public int ReportId { get; set; }
        public int AccountId { get; set; }
    }
}
