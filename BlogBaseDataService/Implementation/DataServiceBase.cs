using BlogBaseDataService.Interfaces;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBaseDataService.Implementation
{
    public abstract class DataServiceBase : IDataServiceInitialize
    {
        private IServiceLocator _serviceLocator;

        private IServiceLocator ServiceLocator
        {
            get
            {
                if (_serviceLocator == null)
                    _serviceLocator = Microsoft.Practices.ServiceLocation.ServiceLocator.Current;
                return _serviceLocator;
            }
        }

        protected IDataAccessService DataAccessService { get; set; }

        public void Initialize(IDataAccessService dataAccessService)
        {
            DataAccessService = dataAccessService;
        }

        protected T ResolveDataService<T>() where T : IDataServiceInitialize
        {
            T service = ServiceLocator.GetInstance<T>();
            SetDataAccessService(service);
            return service;
        }

        protected T ResolveDataService<T>(string key) where T : IDataServiceInitialize
        {
            T service = ServiceLocator.GetInstance<T>(key);
            SetDataAccessService(service);
            return service;
        }

        private void SetDataAccessService<T>(T service) where T : IDataServiceInitialize
        {
            (service as IDataServiceInitialize).Initialize(DataAccessService);
        }
    }
}
