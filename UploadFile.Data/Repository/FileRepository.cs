using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UploadFile.Data.Data;
using UploadFile.Domain.Entities;

namespace UploadFile.Data.Repository
{
    public class FileRepository : IRepository, IDisposable
    {
        private FileUploadContext _context;

        public FileRepository(FileUploadContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<FileInfoEntity>> GetFilesAsync()
        {
            return await _context.Files.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Add(FileInfoEntity fileToAdd)
        {
            if (fileToAdd == null)
            {
                throw new ArgumentNullException(nameof(fileToAdd));
            }

            _context.Add(fileToAdd);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (_context == null)
            {
                return;
            }

            _context.Dispose();
            _context = null;
        }
    }
}