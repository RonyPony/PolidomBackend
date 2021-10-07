using Polidom.Core.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Polidom.Core.Contracts
{
    public interface IReportRepository
    {
        public Task CreateReport(Report report);
        public Task UpdateReport(Report report);
        public Task RemoveReport(Report report);
    }
}
