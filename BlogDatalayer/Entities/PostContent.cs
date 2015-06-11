using BlogDatalayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDatalayer.Entities
{
    public class PostContent : DataEntityBase
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SavedOn { get; set; }
        public bool IsDisplayed { get; set; }
        public int EditedBy { get; set; }
    }
}
