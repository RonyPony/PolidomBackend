using Microsoft.EntityFrameworkCore;
using Polidom.Core.Domains;
using Polidom.Core.Interfaces;
using Polidom.Data.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polidom.Data.Services
{
    public class LocationService : ILocationService
    {
        private readonly PolidomContext _polidomContext;

        public LocationService(PolidomContext polidomContext)
        {
            _polidomContext = polidomContext;
        }

        public async Task<IEnumerable<LocationInfo>> GetAllLocationInfos()
        {
            return await _polidomContext.Locations.ToListAsync();
        }

        public async Task<LocationInfo> GetLocationById(int id)
        {
            if (id == 0)
                throw new Exception("InvalidId");

            return await _polidomContext.Locations
                .FirstOrDefaultAsync(location => location.Id == id);
        }
    }
}
