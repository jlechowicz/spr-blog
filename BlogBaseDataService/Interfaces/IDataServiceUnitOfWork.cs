using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBaseDataService.Interfaces
{
    public interface IDataServiceUnitOfWork : IDisposable
    {
        IDataAccessService DataAccessService { get; }
        T ResolveDataService<T>() where T : IDataServiceInitialize;
        void Save();
        void Update<T>(T entity) where T : class;
    }
}
