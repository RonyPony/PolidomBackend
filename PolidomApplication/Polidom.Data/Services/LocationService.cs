using Microsoft.EntityFrameworkCore;
using Polidom.Core.Domains;
using Polidom.Core.Interfaces;
using Polidom.Data.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polidom.Data.Services
{
    /// <summary>
    /// Represents location service
    /// </summary>
    public class LocationService : ILocationService
    {
        #region Fields

        private readonly PolidomContext _polidomContext;

        #endregion

        #region Ctor

        /// <summary>
        /// <paramref name="polidomContext"/> <see cref="PolidomContext"/> class.
        /// </summary>
        public LocationService(PolidomContext polidomContext)
        {
            _polidomContext = polidomContext;
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public async Task<IEnumerable<LocationInfo>> GetAllLocationInfos()
        {
            return await _polidomContext.Locations.Include("Report").ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<LocationInfo> GetLocationById(int id)
        {
            if (id == 0)
                throw new Exception("InvalidId");

            return await _polidomContext.Locations.Include("Report")
                .FirstOrDefaultAsync(location => location.Id == id);
        }

        #endregion

    }
}
