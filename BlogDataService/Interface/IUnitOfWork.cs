using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDataService.Interface
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        T Fetch<T>(object key);
    }
}
