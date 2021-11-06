using Polidom.Core.Contracts;
using Polidom.Core.Domains;
using Polidom.Data.Data;
using System;
using System.Threading.Tasks;

namespace Polidom.Data.Repository
{
    /// <summary>
    /// Represents report repository
    /// </summary>
    public class ReportRepository : IReportRepository
    {
        #region Fields

        private readonly PolidomContext _polidomContext;

        #endregion

        #region Ctor

        /// <summary>
        /// <paramref name="polidomContext"/> <see cref="PolidomContext"/> class.
        /// </summary>
        public ReportRepository(PolidomContext polidomContext)
        {
            _polidomContext = polidomContext;
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public async Task<int> CreateReport(Report report)
        {
            if (report is null)
                throw new Exception("InvalidReportRequest");

            report.AssignedAuthorityId = false;
            report.CreationDate = DateTime.Now;
            report.IsCompleted = false;
            report.IsDeleted = false;

            _polidomContext.Reports.Add(report);
            await _polidomContext.SaveChangesAsync();
            return report.Id;
        }

        /// <inheritdoc/>
        public async Task RemoveReport(Report report)
        {
            if (report is null)
                throw new Exception("InvalidReportRequest");

            _polidomContext.Reports.Remove(report);
            await _polidomContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateReport(Report report)
        {
            if (report is null)
                throw new Exception("InvalidReportRequest");

            _polidomContext.Reports.Update(report);
            await _polidomContext.SaveChangesAsync();
        }

        #endregion
    }
}
