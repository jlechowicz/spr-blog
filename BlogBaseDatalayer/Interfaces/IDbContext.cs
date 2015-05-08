using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBaseDatalayer.Interfaces
{
    public interface IDbContext : IDisposable
    {
        EntityState GetEntityState<TEntity>(TEntity entity) where TEntity : class;
        string GetTableName<TEntity>() where TEntity : class;
        void SetEntityState<TEntity>(TEntity entity, EntityState state) where TEntity : class;
        IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class;
        EntitySet GetEntitySet<TEntity>() where TEntity : class;
        DbContextConfiguration Configuration { get; }
        int SaveChanges();
        Database Database { get; }
    }
}
