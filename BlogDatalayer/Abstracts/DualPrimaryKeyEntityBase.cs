using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDatalayer.Abstracts
{
    public abstract class DualPrimaryKeyEntityBase
    {
        private int _primaryKey1;
        public int PrimaryKey1 { get { return _primaryKey1; } }
        private int _primaryKey2;
        public int PrimaryKey2 { get { return _primaryKey2; } }
    }
}
