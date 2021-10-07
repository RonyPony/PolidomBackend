using Polidom.Core.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polidom.Core.Interfaces
{
    public interface ILocationService
    {
        public Task<IEnumerable<LocationInfo>> GetAllLocationInfos();
        public Task<LocationInfo> GetLocationById(int id);
    }
}
