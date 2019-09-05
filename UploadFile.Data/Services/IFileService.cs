using System.Collections.Generic;
using System.Threading.Tasks;
using UploadFile.Domain.Entities;
using UploadFile.Domain.Models;

namespace UploadFile.Data.Services
{
    public interface IFileService
    {
        Task<IEnumerable<FileInfoModel>> GetFilesAsync();
        Task AddAsync(FileInfoModel entity);
    }
}