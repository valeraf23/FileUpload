using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using UploadFile.Data.Models;

namespace UploadFile.Extensions
{
    public static class FormFileExtension
    {
        public static FileInfoModel ConvertToFileInfoModel(this IFormFile fileInfo)
        {
            return new FileInfoModel
            {
                Name = fileInfo.Name,
                Size = fileInfo.Length,
                Type = Path.GetExtension(fileInfo.Name),
                LastModifiedDate = DateTime.Now
            };
        }
    }
}