using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDatalayer.Interfaces
{
    public interface IDbContext : IDisposable
    {
        void Save();
        EntityState GetEntityState<TEntity>(TEntity entity) where TEntity : class;
        string GetTableName<TEntity>() where TEntity : class;
        void SetEntityState<TEntity>(TEntity entity, System.Data.Entity.EntityState state) where TEntity : class;
        IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class;
        EntitySet GetEntitySet<TEntity>() where TEntity : class;
    }
}
