using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Polidom.Core.Domains;
using Polidom.Core.Enums;
using Polidom.Core.Interfaces;
using Polidom.Data.Data;
using Polidom.Data.Data.identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly UserManager<Account> _userManager;

        #endregion

        #region Ctor

        /// <summary>
        /// <paramref name="polidomContext"/> <see cref="PolidomContext"/> class.
        /// </summary>

        public ReportService(PolidomContext polidomContext, UserManager<Account> userManager)
        {
            _polidomContext = polidomContext;
            _userManager = userManager;
        }

        public async Task AddingReportToAuthority(int reportId, string accountId)
        {
             _polidomContext.ReportMappings.Add(new AssignReportMapping { 
               AccountId = accountId,
               ReportId = reportId
            });

            await _polidomContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task AssignReportToAuthority(int reportId, string accountId)
        {
            if (reportId == 0)
                throw new ArgumentException("InvalidReportId");
            if (string.IsNullOrWhiteSpace(accountId))
                throw new ArgumentException("InvalidAccountId");

            var account = await _userManager.FindByIdAsync(accountId.ToString());

            if (account.Role.Equals(UserRoleType.Admin.ToString()))
                throw new ArgumentException("RolesInvalidToAssignTheReport");

            if (account is null)
                throw new ArgumentException("AccountNotFound");

            var foundReport = await _polidomContext.Reports
                .FirstOrDefaultAsync(report => report.Id == reportId);

            foundReport.AssignedAuthorityId = true;

            await AddingReportToAuthority(reportId, accountId);

            _polidomContext.Reports.Update(foundReport);

            await _polidomContext.SaveChangesAsync();
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public async Task<IEnumerable<Report>> GetAllReports()
        {
            return await _polidomContext.Reports.Include("Ubicacion")
                .Where( report => report.ReportType != ReportType.Panic).ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetPanicReport()
        {
            return await _polidomContext.Reports
                .Where(report => report.ReportType.Equals(ReportType.Panic))
                .ToListAsync();
        }

        public async Task<Report> GetReportAssignToAccount(string accountId)
        {
            if (accountId == null )
                throw new ArgumentException("InvalidAccountId");

            AssignReportMapping mapping = await _polidomContext.ReportMappings
                .FirstOrDefaultAsync(mapping => mapping.AccountId.Equals(accountId));

            if (mapping is null)
                throw new ArgumentException("NotReportAssignToAuthorityFound");

            return await _polidomContext.Reports.FirstOrDefaultAsync(report => report.Id == mapping.ReportId);
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
        public async Task<IEnumerable<Report>> GetReportsByAccountId(string accountId)
        {
            if (string.IsNullOrWhiteSpace(accountId))
                throw new ArgumentException("InvalidAccountId");

            var account = await _userManager.FindByIdAsync(accountId);

            if (account is null)
                throw new ArgumentException("AccountNotFound");

            return await _polidomContext.Reports
                .Where(report => report.ReporterUserId.Equals(accountId))
                .ToListAsync();
        }

        public async Task MarkReportAsComplete(int reportId, string accountId)
        {
            if (reportId == 0)
                throw new ArgumentException("InvalidReportId");

            if (string.IsNullOrWhiteSpace(accountId))
                throw new ArgumentException("InvalidAccountId");

            var reportMapping = await _polidomContext.ReportMappings.FirstOrDefaultAsync(report => report.ReportId == reportId
            && report.AccountId.Equals(accountId));

            if (reportMapping is null)
                throw new ArgumentException("InvalidUserTryToComplete");

            Report foundReport = await _polidomContext.Reports.FirstOrDefaultAsync(report => report.Id == reportId);

            if (foundReport is null)
                throw new ArgumentException("ReportNotFound");

            foundReport.IsCompleted = true;
            foundReport.AssignedAuthorityId = false;

            _polidomContext.Reports.Update(foundReport);
           await  _polidomContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task RemoveReportAssignToAuthority(int reportId, string accountId)
        {
            if (reportId == 0)
                throw new ArgumentException("InvalidReportId");
            if (string.IsNullOrWhiteSpace(accountId))
                throw new ArgumentException("InvalidAccountId");

            var reportMapping = await _polidomContext.ReportMappings.FirstOrDefaultAsync(report => report.ReportId == reportId 
            && report.AccountId.Equals(accountId));

            if (reportMapping is null)
                throw new ArgumentException("ReportAssignNotFound");

            _polidomContext.ReportMappings.Remove(reportMapping);
            await _polidomContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<int> ReportCount()
        {
            return await _polidomContext.Reports.CountAsync();
        }

        #endregion
    }
}
