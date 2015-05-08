using BlogBaseDatalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDatalayer
{
    [Export(typeof(IDbContext))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class BlogDatabaseEntities : IDbContext
    {
        public System.Data.Entity.EntityState GetEntityState<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public string GetTableName<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void SetEntityState<TEntity>(TEntity entity, System.Data.Entity.EntityState state) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public System.Data.Entity.IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public System.Data.Entity.Core.Metadata.Edm.EntitySet GetEntitySet<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public System.Data.Entity.Infrastructure.DbContextConfiguration Configuration
        {
            get { throw new NotImplementedException(); }
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public System.Data.Entity.Database Database
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
