using Polidom.Core.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polidom.Core.Interfaces
{
    public interface IPhotoService
    {
        public Task<IEnumerable<Photo>> GetPhotos();
        public Task<Photo> GetPhotoById(int id);
        public Task<IEnumerable<Photo>> GetPhotosByReportId(int reportId);
        public Task  CreatePhoto(Photo photo);
        public Task  UpdatePhoto(Photo photo);
        public Task  DeletePhoto(Photo photo);
    }
}
