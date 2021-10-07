using Polidom.Core.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polidom.Core.Interfaces
{
    public interface IReportService
    {
        public Task<IEnumerable<Report>> GetAllReports();
        public Task<Report> GetReportById(int id);
    }
}
