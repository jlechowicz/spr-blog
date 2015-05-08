using BlogBaseDatalayer.Interfaces;
using BlogBaseDataService.Interfaces;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogBaseDataService.Implementation
{
    [Export(typeof(IDataAccessService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DataAccessService : IDataAccessService
    {
        private IDbContext _dbContext;
        protected IDbContext DbContext
        {
            get
            {
                if (_dbContext == null)
                    _dbContext = ServiceLocator.Current.GetInstance<IDbContext>();
                return _dbContext;
            }
            set
            {
                _dbContext = value;
            }
        }

        public virtual void Add<TEntity>(TEntity entity) where TEntity : class
        {
            GetDbSet<TEntity>().Add(entity);
        }

        public virtual void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            IDbSet<TEntity> dbSet = GetDbSet<TEntity>();
            if (DbContext.GetEntityState(entity) == EntityState.Detached)
                dbSet.Attach(entity);
            dbSet.Remove(entity);
        }

        public virtual void Update<TEntity>(TEntity entity) where TEntity : class
        {

            if (AlreadyAttached(entity))
                return;
            GetDbSet<TEntity>().Attach(entity);
            DbContext.SetEntityState(entity, EntityState.Modified);
        }

        private bool AlreadyAttached<TEntity>(TEntity entity) where TEntity : class
        {
            return GetDbSet<TEntity>().Local.Any(e => e == entity);
        }

        public virtual void DeleteById<TEntity>(long id) where TEntity : class
        {
            TEntity entity = GetById<TEntity>(id);
            Delete(entity);
        }

        public virtual TEntity GetById<TEntity>(long id) where TEntity : class
        {
            return GetDbSet<TEntity>().Find(id);
        }

        public virtual TEntity GetById<TEntity>(Guid id) where TEntity : class
        {
            return GetDbSet<TEntity>().Find(id);
        }

        public virtual IQueryable<TEntity> All<TEntity>() where TEntity : class
        {
            return GetDbSet<TEntity>();
        }

        public virtual IQueryable<TEntity> NoTracking<TEntity>() where TEntity : class
        {
            return GetDbSet<TEntity>().AsNoTracking();
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return DbContext.Database.ExecuteSqlCommand(sql, parameters);
        }

        public int ExecuteSqlCommand(TimeSpan timeout, string sql, params object[] parameters)
        {
            var currentTimeout = DbContext.Database.CommandTimeout;
            DbContext.Database.CommandTimeout = (int)timeout.TotalSeconds;
            int rVal = ExecuteSqlCommand(sql, parameters);
            DbContext.Database.CommandTimeout = currentTimeout;
            return rVal;

        }
        public IEnumerable<T> ExecuteStoredProc<T>(string sql, params object[] parameters)
        {
            return DbContext.Database.SqlQuery<T>(sql, parameters);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return DbContext.GetDbSet<TEntity>();
        }

        ~DataAccessService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                    DbContext = null;
                }
            }
        }

        public bool IsEntityModified<TEntity>(TEntity entity) where TEntity : class
        {
            return DbContext.GetEntityState(entity) == EntityState.Modified;
        }
    }
}
