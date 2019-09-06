using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using UploadFile.Data.Models;

namespace UploadFile.Extensions
{
    public static class FormFileExtension
    {
        public static FileInfoModel ConvertToFileInfoModel(this IFormFile fileInfo)
        {
            return new FileInfoModel
            {
                Name = Path.GetFileNameWithoutExtension(fileInfo.FileName),
                Size = fileInfo.Length,
                Type = Path.GetExtension(fileInfo.FileName),
                LastModifiedDate = DateTime.Now
            };
        }
    }
}