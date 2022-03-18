using System;
using System.Linq;
using System.Linq.Expressions;

namespace LibraryManager.Models.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Read();
        T Read(int id);
        T Add(T entry);
        bool Edit(T entry);
        bool Delete(T entry);
        bool Delete(int id);
        bool Exist(Expression<Func<T, bool>> predicate);
    }
}
