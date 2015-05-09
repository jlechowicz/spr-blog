using BlogBaseDataService.Implementation;
using BlogBaseDataService.Interfaces;
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
        private ServiceDataAccessHandle _serviceDataAccessHandler;
        private IDataServiceUnitOfWork _dataServiceUnitOfWork;
        public IServiceLocator CurrentServiceLocator
        {
            get
            {
                return ServiceLocator.Current;
            }
        }

        public IDataServiceUnitOfWork DataServiceUnitOfWork
        {
            get
            {
                if (_dataServiceUnitOfWork == null)
                {
                    _dataServiceUnitOfWork = CurrentServiceLocator.GetInstance<IDataServiceUnitOfWork>();
                }
                return _dataServiceUnitOfWork;
            }
        }

        public ServiceDataAccessHandle ServiceDataAccessHandler
        {
            get
            {
                if (_serviceDataAccessHandler == null)
                {
                    _serviceDataAccessHandler = new ServiceDataAccessHandle(true, _dataServiceUnitOfWork);
                }
                return _serviceDataAccessHandler;
            }
        }
    }
}
