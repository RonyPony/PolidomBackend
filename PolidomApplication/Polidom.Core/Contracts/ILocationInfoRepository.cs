using Polidom.Core.Domains;
using System.Threading.Tasks;

namespace Polidom.Core.Contracts
{
    /// <summary>
    /// Represents a contract repository of location info.
    /// </summary>
    public interface ILocationInfoRepository
    {
        /// <summary>
        /// Registe a new record of location data.
        /// </summary>
        /// <param name="location">Location's request</param>
        public Task CreateLocation(LocationInfo location);

        /// <summary>
        /// Update a specific record of location data.
        /// </summary>
        /// <param name="location">Location's request</param>
        /// <returns></returns>
        public Task UpdateLocation(LocationInfo location);

        /// <summary>
        /// Remove a specific record of location data.
        /// </summary>
        /// <param name="location">Location's request</param>
        /// <returns></returns>
        public Task RemoveLocation(LocationInfo location);
    }
}
