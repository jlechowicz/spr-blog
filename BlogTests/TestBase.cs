using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTests
{
    public abstract class TestBase
    {
        public IServiceLocator CurrentServiceLocator
        {
            get
            {
                return ServiceLocator.Current;
            }
        }
    }
}
