using Microsoft.EntityFrameworkCore;
using Polidom.Core.Domains;
using Polidom.Core.Interfaces;
using Polidom.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Polidom.Data.Services
{
    public class ReportService : IReportService
    {
        private readonly PolidomContext _polidomContext;

        public ReportService(PolidomContext polidomContext)
        {
            _polidomContext = polidomContext;
        }

        public async Task<IEnumerable<Report>> GetAllReports()
        {
            return await _polidomContext.Reports.Include("Ubicacion").ToListAsync();
        }

        public async Task<Report> GetReportById(int id)
        {
            if (id == 0)
                throw new Exception("InvalidId");

            return await _polidomContext.Reports.Include("Ubicacion")
                .FirstOrDefaultAsync(report => report.Id == id);
        }

        public async Task<int> ReportCount()
        {
            return await _polidomContext.Reports.CountAsync();
        }
    }
}
