using BlogDatalayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogDatalayer.Entities
{
    public class Role : DataEntityBase
    {
        public string RoleName { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
