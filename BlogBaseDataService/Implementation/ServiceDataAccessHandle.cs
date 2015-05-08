using BlogBaseDataService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBaseDataService.Implementation
{
    public class ServiceDataAccessHandle : IDisposable
    {
        private readonly bool _disposeUnitOfWork;
        private IDataServiceUnitOfWork _dataServiceUnitOfWork;

        public ServiceDataAccessHandle(bool disposeUnitOfWork, IDataServiceUnitOfWork dataServiceUnitOfWork)
        {
            _disposeUnitOfWork = disposeUnitOfWork;
            _dataServiceUnitOfWork = dataServiceUnitOfWork;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        ~ServiceDataAccessHandle()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_disposeUnitOfWork && _dataServiceUnitOfWork != null)
                {
                    _dataServiceUnitOfWork.Dispose();
                    _dataServiceUnitOfWork = null;
                }
            }
        }
    }
}
