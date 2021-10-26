using Microsoft.EntityFrameworkCore;
using Polidom.Core.Domains;
using Polidom.Core.Interfaces;
using Polidom.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polidom.Data.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly PolidomContext _polidomContext;

        public PhotoService(PolidomContext polidomContext)
        {
            _polidomContext = polidomContext;
        }

        public async Task CreatePhoto(Photo photo)
        {
            if (photo is null)
                throw new ArgumentException("InvalidPhotoRequest");

            _polidomContext.Photos.Add(photo);
            await _polidomContext.SaveChangesAsync();
        }

        public async Task DeletePhoto(Photo photo)
        {
            if (photo is null)
                throw new ArgumentException("InvalidPhotoRequest");

            _polidomContext.Remove(photo);
            await _polidomContext.SaveChangesAsync();
        }

        public async Task<Photo> GetPhotoById(int id)
        {
            if (id == 0)
                throw new ArgumentException("InvalidId");

            return await _polidomContext.Photos.FirstOrDefaultAsync(photo => photo.Id == id);
        }

        public async Task<IEnumerable<Photo>> GetPhotos()
        {
            return await _polidomContext.Photos.ToListAsync();
        }

        public async Task<IEnumerable<Photo>> GetPhotosByReportId(int reportId)
        {
            if (reportId == 0)
                throw new ArgumentException("InvalidId");

            return await _polidomContext.Photos.Where(photo => photo.ReportId == reportId).ToListAsync();
        }

        public async Task UpdatePhoto(Photo photo)
        {
            if (photo is null)
                throw new ArgumentException("InvalidPhotoRequest");

            _polidomContext.Photos.Update(photo);
            await _polidomContext.SaveChangesAsync();
        }

        
    }
}
