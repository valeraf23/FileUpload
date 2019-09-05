using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UploadFile.Domain.Entities
{
    public class FileInfoEntity : IEntity
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
        public DateTime LastModifiedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}