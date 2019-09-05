using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using UploadFile.Domain.Models;

namespace UploadFile.Extensions
{
    public static class FileInfoExtension
    {
        public static FileInfoModel ConvertToFileInfoModel(this IFileInfo fileInfo)
        {
            return new FileInfoModel
            {
                Name = fileInfo.Name,
                Size = fileInfo.Length,
                Type = Path.GetExtension(fileInfo.Name),
                LastModifiedDate = fileInfo.LastModified.DateTime

            };
        }
    }
}
