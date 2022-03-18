using LibraryManager.Models.Domains;
using LibraryManager.Models.ViewModels;
using LibraryManager.Models.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryManager.Models.Services.Contracts
{
    public interface ICategoryService
    {
        IQueryable<Category> Read();
        Pagination<DetailsCategory> Paginate(Paginator entry);
        DetailsCategory Details(int id);
        DetailsCategory Create(CreateCategory entry);
        DetailsCategory Update(int id, CreateCategory entry);
        bool Remove(int id);
        bool Exist(Expression<Func<Category, bool>> predicate);
        bool Exist(int id);
    }
}
