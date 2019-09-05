using System.Collections.Generic;
using System.Threading.Tasks;
using UploadFile.Domain.Entities;

namespace UploadFile.Data.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<FileInfoEntity>> GetFilesAsync();
        Task<bool> SaveAsync();
        void Add(FileInfoEntity entity);
    }
}
