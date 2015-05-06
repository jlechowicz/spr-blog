using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDatalayer.Interface
{
    public interface IRepository
    {
        void Save();
        void Rollback();
        void Add<T>(T Entity);
        void Update<T>(T Entity);
        void Delete<T>(T Entity);
        void Attach<T>(T Entity);
        void Detatch<T>(T Entity);
        T Find<T>(object key);
        IQueryable<T> All<T>();
    }
}
