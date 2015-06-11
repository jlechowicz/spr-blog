using BlogDatalayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDatalayer.Entities
{
    public class Post : DataEntityBase
    {
        public int AuthorId { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
        public virtual ICollection<PostContent> PostContents { get; set; }
    }
}
