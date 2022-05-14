using LibraryManager.Models.Domains;
using LibraryManager.Models.Repositories;
using LibraryManager.Models.Services.Contracts;
using LibraryManager.Models.ViewModels;
using LibraryManager.Models.ViewModels.LibraryItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LibraryManager.Models.Services.Persistence
{
    public class LibraryItemService : ILibraryItemService
    {
        private  IRepository<LibraryItem> Repository { get; }

        public LibraryItemService(IRepository<LibraryItem> repository)
        {
            Repository = repository;
        }

        public T Create<T>(BaseLibraryItem entry) where T : BaseLibraryItem, new()
        {
            LibraryItem item = entry.MapGetter();

            item = Repository.Add(item);

            T result = new T();

            result.MapSetter(item);

            return result;
        }

        public T Details<T>(int id) where T : BaseLibraryItem, new()
        {
            T result = null;

            if (Exist(id))
            {
                LibraryItem item = Repository.Read(id);

                result = new T();
                result.MapSetter(item);
            }

            return result;
        }

        public bool Exist(Expression<Func<LibraryItem, bool>> predicate)
        {
            return Read().Any(predicate);
        }

        public bool Exist(int id)
        {
            return Exist(item => item.Id == id);
        }

        public Pagination<T> Paginate<T>(PaginatorLibraryItem entry) where T : BaseLibraryItem, new()
        {
            Pagination<T> result = new Pagination<T>()
            {
                TotalRecords = Repository.Read().Count(),
                PageIndex = entry.PageIndex
            };

            result.TotalPages = (int)Math.Ceiling(result.TotalRecords / (double)entry.PageSize);

            if (entry.PageIndex <= result.TotalPages)
            {
                int offset = entry.PageIndex > 1 ? (entry.PageIndex - 1) * entry.PageSize : 0;

                IQueryable<LibraryItem> query = Repository.Read();

                if(!string.IsNullOrEmpty(entry.Type))
                {
                    query = query.Where(item => item.Type.Equals(entry.Type));
                }

                List<LibraryItem> items = query
                    .OrderBy(category => category.Id)
                    .Skip(offset)
                    .Take(entry.PageSize)
                    .ToList();

                result.Records = items
                    .Select(item => { T result = new T(); result.MapSetter(item); return result; })
                    .ToList();
            }

            result.PageSize = result.Records.Count;

            return result;
        }

        public IQueryable<LibraryItem> Read()
        {
            return Repository.Read();
        }

        public bool Remove(int id)
        {
            return Repository.Delete(id);
        }

        public T Update<T>(int id, BaseLibraryItem entry) where T : BaseLibraryItem, new()
        {
            T result = null;

            if(Exist(id))
            {
                LibraryItem item = entry.MapGetter();

                item.Id = id;

                if (Exist(library => library.Id == item.Id && library.Type == item.Type))
                {
                    if (Repository.Edit(item))
                    {
                        result = new T();
                        result.MapSetter(item);
                    }
                }
            }

            return result;
        }
    }
}
