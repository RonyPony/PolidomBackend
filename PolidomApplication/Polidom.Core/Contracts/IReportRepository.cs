using Polidom.Core.Domains;
using System.Threading.Tasks;

namespace Polidom.Core.Contracts
{
    /// <summary>
    /// Represent a contract of report.
    /// </summary>
    public interface IReportRepository
    {
        /// <summary>
        /// Register a new record of report data.
        /// </summary>
        /// <param name="report">Report's request</param>
        public Task CreateReport(Report report);

        /// <summary>
        /// Update a specific record of report data.
        /// </summary>
        /// <param name="report">Report's request</param>
        public Task UpdateReport(Report report);

        /// <summary>
        ///  Remove a specific record of report data.
        /// </summary>
        /// <param name="report">Report's request</param>
        public Task RemoveReport(Report report);
    }
}
