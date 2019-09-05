using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using UploadFile.Domain.Entities;

namespace UploadFile.Data.Data
{
    public class FileUploadContext : DbContext
    {
        public FileUploadContext(DbContextOptions<FileUploadContext> options)
            : base(options)
        {
        }

        public DbSet<FileInfoEntity> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FileInfoEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}