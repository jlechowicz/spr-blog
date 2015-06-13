using BlogDatalayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDatalayer.Entities
{
    public class MimeType : DataEntityBase
    {
        public string Definition { get; set; }
        public string AssociatedFileExtensions { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}
