using LibraryManager.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace LibraryManager.Models.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext Database { get; }
        private DbSet<T> Table { get; }

        public Repository(LibraryContext context)
        {
            Database = context;
            Table = Database.Set<T>();
            if(Table == null)
            {
                throw new Exception();
            }
        }

        public T Add(T entry)
        {
            Table.Add(entry);

            Database.SaveChanges();

            return entry;
        }

        public bool Delete(T entry)
        {
            Table.Remove(entry);

            return Database.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            T entry = Read(id);

            return entry != null && Delete(entry);
        }

        public bool Edit(T entry)
        {
            Table.Update(entry);

            return Database.SaveChanges() > 0;
        }

        public bool Exist(Expression<Func<T, bool>> predicate)
        {
            return Read().Any(predicate);
        }

        public IQueryable<T> Read()
        {
            return Table;
        }

        public T Read(int id)
        {
            return Table.Find(id);
        }
    }
}
