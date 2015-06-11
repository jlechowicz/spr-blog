namespace BlogDatalayer.DataContexts
{
    using BlogDatalayer.Interfaces;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BlogEntities : DbContext, IDbContext
    {
        public BlogEntities()
            : base("name=BlogEntities")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }

        public void Create<EntityType>() where EntityType : class
        {
            throw new NotImplementedException();
        }

        public void Add<EntityType>(EntityType Entity) where EntityType : class
        {
            throw new NotImplementedException();
        }

        public void Update<EntityType>(EntityType Entity) where EntityType : class
        {
            throw new NotImplementedException();
        }

        public void Delete<EntityType>(EntityType Entity) where EntityType : class
        {
            throw new NotImplementedException();
        }

        public void Attach<EntityType>(EntityType Entity) where EntityType : class
        {
            throw new NotImplementedException();
        }

        public void Detatch<EntityType>(EntityType Entity) where EntityType : class
        {
            throw new NotImplementedException();
        }

        public EntityType Find<EntityType>(params object[] keys) where EntityType : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<EntityType> All<EntityType>() where EntityType : class
        {
            throw new NotImplementedException();
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}