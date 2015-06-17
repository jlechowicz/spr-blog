namespace BlogDatalayer.DataContexts
{
    using BlogDatalayer.Interfaces;
    using BlogDatalayer.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.Composition;
    using System.Data.Entity.Infrastructure;
    using System.Text.RegularExpressions;
    using BlogDatalayer.Configuration;

    [Export(typeof(IDbContext))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BlogEntities : DbContext, IDbContext
    {
        public BlogEntities()
            : base("name=BlogEntities")
        {
 
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<PostTag> PostTags { get; set; }

        public virtual DbSet<PostContent> PostContents { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<File> Files { get; set; }

        public virtual DbSet<MimeType> MimeTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigurationBinder.Bind(modelBuilder);
        }

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

        public void Save()
        {
            base.SaveChanges();
        }
    }
}