using BlogDatalayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDatalayer.Entities
{
    public class PostTag : DualPrimaryKeyEntityBase
    {
        public int PostId { get; set; }
        public int TagId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }

        public PostTag()
        {
            _primaryKey1 = PostId;
            _primaryKey2 = TagId;
        }
    }
}
