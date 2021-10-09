using Polidom.Core.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polidom.Core.Interfaces
{
    /// <summary>
    /// Represent a contract of location for the service.
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Retrieves all location info data.
        /// </summary>
        /// <returns>a list of locations</returns>
        public Task<IEnumerable<LocationInfo>> GetAllLocationInfos();

        /// <summary>
        /// Retrieves a specific location data by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a location</returns>
        public Task<LocationInfo> GetLocationById(int id);
    }
}
