using BlogBaseDatalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlogDatalayer
{
    [Export(typeof(IDbContext))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class BlogDatabaseEntities : IDbContext
    {
        public System.Data.Entity.EntityState GetEntityState<TEntity>(TEntity entity) where TEntity : class
        {
            return this.Entry(entity).State;
        }

        public string GetTableName<TEntity>() where TEntity : class
        {
            var sql = ((IObjectContextAdapter)this).ObjectContext.CreateObjectSet<TEntity>().ToTraceString();
            Regex regex = new Regex("FROM (?<table>.*) AS");
            Match match = regex.Match(sql);

            string table = match.Groups["table"].Value;
            return table;
        }

        public void SetEntityState<TEntity>(TEntity entity, System.Data.Entity.EntityState state) where TEntity : class
        {
            Entry(entity).State = state;
        }

        public System.Data.Entity.IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public System.Data.Entity.Core.Metadata.Edm.EntitySet GetEntitySet<TEntity>() where TEntity : class
        {
            var set = ((IObjectContextAdapter)this).ObjectContext.CreateObjectSet<TEntity>();
            var entitySet = set.EntitySet;
            return entitySet;
        }

        public System.Data.Entity.Infrastructure.DbContextConfiguration Configuration
        {
            get { return null; }
        }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }

        public System.Data.Entity.Database Database
        {
            get { return base.Database; }
        }

        public void Dispose()
        {
            base.Dispose();
        }
    }
}
