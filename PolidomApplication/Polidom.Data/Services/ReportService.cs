using Microsoft.EntityFrameworkCore;
using Polidom.Core.Domains;
using Polidom.Core.Interfaces;
using Polidom.Data.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polidom.Data.Services
{
    /// <summary>
    /// Represents report service.
    /// </summary>
    public class ReportService : IReportService
    {
        #region Fields

        private readonly PolidomContext _polidomContext;

        #endregion

        #region Ctor

        /// <summary>
        /// <paramref name="polidomContext"/> <see cref="PolidomContext"/> class.
        /// </summary>

        public ReportService(PolidomContext polidomContext)
        {
            _polidomContext = polidomContext;
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public async Task<IEnumerable<Report>> GetAllReports()
        {
            return await _polidomContext.Reports.Include("Ubicacion").ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Report> GetReportById(int id)
        {
            if (id == 0)
                throw new Exception("InvalidId");

            return await _polidomContext.Reports.Include("Ubicacion")
                .FirstOrDefaultAsync(report => report.Id == id);
        }

        /// <inheritdoc/>
        public async Task<int> ReportCount()
        {
            return await _polidomContext.Reports.CountAsync();
        }

        #endregion
    }
}
