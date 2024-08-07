﻿using Polidom.Core.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polidom.Core.Interfaces
{
    /// <summary>
    /// Represent a contract of report of the service.
    /// </summary>
    public interface IReportService
    {
        /// <summary>
        /// Retrives all report data.
        /// </summary>
        /// <returns>list of reports</returns>
        public Task<IEnumerable<Report>> GetAllReports();

        /// <summary>
        /// Retrieves all report by account id.
        /// </summary>
        /// <param name="accountId">Account's id</param>
        /// <returns></returns>
        public Task<IEnumerable<Report>> GetReportsByAccountId(string accountId);

        /// <summary>
        /// Retrieves report assign to account
        /// </summary>
        /// <param name="accountId">Account's id</param>
        /// <returns></returns>
        public Task<Report> GetReportAssignToAccount(string accountId);

        /// <summary>
        /// Retrieves a especific report data by id
        /// </summary>
        /// <param name="id">Report's id</param>
        /// <returns>a report</returns>
        public Task<Report> GetReportById(int id);
        /// <summary>
        /// Retrieves panic report data 
        /// </summary>
        /// <returns>a report list</returns>
        public Task<IEnumerable<Report>> GetPanicReport();

        /// <summary>
        /// Retrieves a count of report data stored
        /// </summary>
        /// <returns>the count number</returns>
        public Task<int> ReportCount();

        /// <summary>
        /// Assign a report to authority.
        /// </summary>
        /// <param name="reportId">Report's id</param>
        /// <param name="accountId">Account's id</param>
        public Task AssignReportToAuthority(int reportId, string accountId);

        /// <summary>
        /// Remove a report assigned to authority account.
        /// </summary>
        /// <param name="reportId">Report's id</param>
        /// <param name="accountId">Account's id</param>
        /// <returns></returns>
        public Task RemoveReportAssignToAuthority(int reportId, string accountId);

        /// <summary>
        /// Adding to report mapping .
        /// </summary>
        /// <param name="reportId">Report's id</param>
        /// <param name="accountId">Account's id</param>
        /// <returns></returns>
        public Task AddingReportToAuthority(int reportId, string accountId);

        /// <summary>
        /// Mark the Report 
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        public Task MarkReportAsComplete(int reportId , string accountId);
    }
}
