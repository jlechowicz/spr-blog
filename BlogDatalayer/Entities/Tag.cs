using BlogDatalayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDatalayer.Entities
{
    public class Tag : DataEntityBase
    {
        public string TagName { get; set; }
    }
}
