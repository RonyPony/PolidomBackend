using Polidom.Core.Contracts;
using Polidom.Core.Domains;
using Polidom.Data.Data;
using System;
using System.Threading.Tasks;

namespace Polidom.Data.Repository
{
    /// <summary>
    /// Represents location repository.
    /// </summary>
    public class LocationInfoRepository : ILocationInfoRepository
    {
        #region Fields

        private readonly PolidomContext _polidomContext;

        #endregion

        #region Ctor

        /// <summary>
        /// <paramref name="polidomContext"/> <see cref="PolidomContext"/> class.
        /// </summary>
        public LocationInfoRepository(PolidomContext polidomContext)
        {
            _polidomContext = polidomContext;
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public async Task CreateLocation(LocationInfo location)
        {
            if (location is null)
                throw new Exception("InvalidLocationRequest");

            _polidomContext.Locations.Add(location);
            await _polidomContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task RemoveLocation(LocationInfo location)
        {
            if (location is null)
                throw new Exception("InvalidLocationRequest");

            _polidomContext.Locations.Remove(location);
            await _polidomContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateLocation(LocationInfo location)
        {
            if (location is null)
                throw new Exception("InvalidLocationRequest");

            _polidomContext.Locations.Update(location);
            await _polidomContext.SaveChangesAsync();
        }

        #endregion
    }
}
