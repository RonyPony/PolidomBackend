using Polidom.Core.Contracts;
using Polidom.Core.Domains;
using Polidom.Data.Data;
using System;
using System.Threading.Tasks;

namespace Polidom.Data.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly PolidomContext _polidomContext;

        public ReportRepository(PolidomContext polidomContext)
        {
            _polidomContext = polidomContext;
        }

        public async Task CreateReport(Report report)
        {
            if (report is null)
                throw new Exception("InvalidReportRequest");

            _polidomContext.Reports.Add(report);
            await _polidomContext.SaveChangesAsync();
        }

        public async Task RemoveReport(Report report)
        {
            if (report is null)
                throw new Exception("InvalidReportRequest");

            _polidomContext.Reports.Remove(report);
            await _polidomContext.SaveChangesAsync();
        }

        public async Task UpdateReport(Report report)
        {
            if (report is null)
                throw new Exception("InvalidReportRequest");

            _polidomContext.Reports.Update(report);
            await _polidomContext.SaveChangesAsync();
        }
    }
}
