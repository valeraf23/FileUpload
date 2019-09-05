using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UploadFile.Domain.Entities;

namespace UploadFile.Data.EntityTypeConfigurations
{
    internal class FileInfoEntityTypeConfiguration : IEntityTypeConfiguration<FileInfoEntity>
    {
        public void Configure(EntityTypeBuilder<FileInfoEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}