using Polidom.Core.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Polidom.Core.Contracts
{
    public interface ILocationInfoRepository
    {
        public Task CreateLocation(LocationInfo location);
        public Task UpdateLocation(LocationInfo location);
        public Task RemoveLocation(LocationInfo location);
    }
}
