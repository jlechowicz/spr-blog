using BlogBaseDataService.Interfaces;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBaseDataService.Implementation
{
    [Export(typeof(IDataServiceUnitOfWork))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DataServiceUnitOfWork : IDataServiceUnitOfWork
    {
        private readonly IList<IDataService> _initializedServices = new List<IDataService>();

        private IDataAccessService _dataAccessService;
        public IDataAccessService DataAccessService
        {
            get
            {
                if (_dataAccessService == null)
                    _dataAccessService = ServiceLocator.GetInstance<IDataAccessService>();
                return _dataAccessService;
            }
            protected set { _dataAccessService = value; }
        }

        protected IServiceLocator ServiceLocator
        {
            get
            {
                return Microsoft.Practices.ServiceLocation.ServiceLocator.Current;
            }
        }

        public T ResolveDataService<T>() where T : IDataServiceInitialize
        {
            T service = (T)_initializedServices.FirstOrDefault(a => a is T);
            if (service == null)
            {
                service = ServiceLocator.GetInstance<T>();
                (service as IDataServiceInitialize).Initialize(DataAccessService);
                _initializedServices.Add(service as IDataService);
            }
            return service;
        }

        public void Save()
        {
            DataAccessService.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            DataAccessService.Update(entity);
            DataAccessService.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DataServiceUnitOfWork()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DataAccessService != null)
                {
                    DataAccessService.Dispose();
                    DataAccessService = null;
                }
            }
        }
    }
}
