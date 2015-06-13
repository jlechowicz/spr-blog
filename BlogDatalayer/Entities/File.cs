using BlogDatalayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDatalayer.Entities
{
    public class File : DataEntityBase
    {
        public string FileName { get; set; }
        public int MimeTypeId { get; set; }
        public byte[] FileData { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual MimeType MimeType { get; set; }
    }
}
