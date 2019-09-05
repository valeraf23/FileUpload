using UploadFile.Data.Models;
using UploadFile.Domain.Entities;

namespace UploadFile.Data.Helpers
{
    public static class MapperExtension
    {
        public static FileInfoModel ToModel(this FileInfoEntity entity)
        {
            return new FileInfoModel
            {
                LastModifiedDate = entity.LastModifiedDate,
                Name = entity.Name,
                Size = entity.Size,
                Type = entity.Type
            };
        }

        public static FileInfoEntity ToEntity(this FileInfoModel entity)
        {
            return new FileInfoEntity
            {
                LastModifiedDate = entity.LastModifiedDate,
                Name = entity.Name,
                Size = entity.Size,
                Type = entity.Type
            };
        }
    }
}