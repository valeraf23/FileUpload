using System;

namespace UploadFile.Data.Models
{
    public class FileInfoModel : IModel
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}