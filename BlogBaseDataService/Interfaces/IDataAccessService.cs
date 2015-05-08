using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBaseDataService.Interfaces
{
    public interface IDataAccessService : IDisposable
    {
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        TEntity GetById<TEntity>(long id) where TEntity : class;
        TEntity GetById<TEntity>(Guid id) where TEntity : class;
        void DeleteById<TEntity>(long id) where TEntity : class;
        bool IsEntityModified<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<TEntity> All<TEntity>() where TEntity : class;
        IQueryable<TEntity> NoTracking<TEntity>() where TEntity : class;
        void SaveChanges();
        int ExecuteSqlCommand(string sql, params object[] parameters);
        int ExecuteSqlCommand(TimeSpan timeOut, string sql, params object[] parameters);
        IEnumerable<T> ExecuteStoredProc<T>(string spName, params object[] parameters);
    }
}
