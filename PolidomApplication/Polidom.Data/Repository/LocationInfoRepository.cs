using Polidom.Core.Contracts;
using Polidom.Core.Domains;
using Polidom.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Polidom.Data.Repository
{
    public class LocationInfoRepository : ILocationInfoRepository
    {
        private readonly PolidomContext _polidomContext;

        public LocationInfoRepository(PolidomContext polidomContext)
        {
            _polidomContext = polidomContext;
        }

        public async Task CreateLocation(LocationInfo location)
        {
            if (location is null)
                throw new Exception("InvalidLocationRequest");

            _polidomContext.Locations.Add(location);
            await _polidomContext.SaveChangesAsync();
        }

        public async Task RemoveLocation(LocationInfo location)
        {
            if (location is null)
                throw new Exception("InvalidLocationRequest");

            _polidomContext.Locations.Remove(location);
            await _polidomContext.SaveChangesAsync();
        }

        public async Task UpdateLocation(LocationInfo location)
        {
            if (location is null)
                throw new Exception("InvalidLocationRequest");

            _polidomContext.Locations.Update(location);
            await _polidomContext.SaveChangesAsync();
        }
    }
}
