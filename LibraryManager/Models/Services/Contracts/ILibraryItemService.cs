using LibraryManager.Models.ViewModels;
using LibraryManager.Models.ViewModels.LibraryItem;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace LibraryManager.Models.Services.Contracts
{
    public interface ILibraryItemService
    {
        IQueryable<Domains.LibraryItem> Read();
        Pagination<T> Paginate<T>(PaginatorLibraryItem entry) where T : BaseLibraryItem, new();
        T Details<T>(int id) where T : BaseLibraryItem, new();
        T Create<T>(BaseLibraryItem entry) where T : BaseLibraryItem, new();
        T Update<T>(int id, BaseLibraryItem entry) where T : BaseLibraryItem, new();
        bool Remove(int id);
        bool Exist(Expression<Func<Domains.LibraryItem, bool>> predicate);
        bool Exist(int id);
    }
}
