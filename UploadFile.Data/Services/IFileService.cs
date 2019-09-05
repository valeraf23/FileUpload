using System.Collections.Generic;
using System.Threading.Tasks;
using UploadFile.Data.Models;

namespace UploadFile.Data.Services
{
    public interface IFileService
    {
        Task<IEnumerable<FileInfoModel>> GetFilesAsync();
        Task AddAsync(FileInfoModel entity);
    }
}