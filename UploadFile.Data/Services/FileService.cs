using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadFile.Data.Helpers;
using UploadFile.Data.Models;
using UploadFile.Data.Repository;

namespace UploadFile.Data.Services
{
    public class FileService : IFileService
    {
        protected readonly IRepository Repository;

        protected FileService(IRepository repository)
        {
            Repository = repository ??
                         throw new ArgumentNullException(nameof(repository),
                             "repository is null.");
        }

        public async Task<IEnumerable<FileInfoModel>> GetFilesAsync()
        {
            var files = await Repository.GetFilesAsync();
            return files.Select(x => x.ToModel());
        }

        public async Task AddAsync(FileInfoModel entity)
        {
            Repository.Add(entity.ToEntity());
            await Repository.SaveAsync();
        }
    }
}