using System;

namespace UploadFile.Domain.Models
{
    public class FileInfoModel
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
}
