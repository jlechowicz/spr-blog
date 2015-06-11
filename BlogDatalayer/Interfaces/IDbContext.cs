using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDatalayer.Interfaces
{
    public interface IDbContext
    {
        void Save();
        void Create<EntityType>() where EntityType : class;
        void Add<EntityType>(EntityType Entity) where EntityType : class;
        void Update<EntityType>(EntityType Entity) where EntityType : class;
        void Delete<EntityType>(EntityType Entity) where EntityType : class;
        void Attach<EntityType>(EntityType Entity) where EntityType : class;
        void Detatch<EntityType>(EntityType Entity) where EntityType : class;
        EntityType Find<EntityType>(params object[] keys) where EntityType : class;
        IQueryable<EntityType> All<EntityType>() where EntityType : class;
    }
}
