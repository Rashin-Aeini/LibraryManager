using LibraryManager.Models.Domains;
using LibraryManager.Models.Repositories;
using LibraryManager.Models.Services.Contracts;
using LibraryManager.Models.ViewModels;
using LibraryManager.Models.ViewModels.Category;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace LibraryManager.Models.Services.Persistence
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> Repository { get; }

        public CategoryService(IRepository<Category> repository)
        {
            Repository = repository;
        }


        public DetailsCategory Create(CreateCategory entry)
        {
            Category item = new Category()
            {
                CategoryName = entry.Name
            };

            item = Repository.Add(item);

            DetailsCategory result = new DetailsCategory()
            {
                Id = item.Id,
                Name = item.CategoryName
            };

            return result;
        }

        public bool Remove(int id)
        {
            return Exist(id) && Repository.Delete(id);
        }

        public DetailsCategory Details(int id)
        {
            DetailsCategory result = null;

            if (Exist(id))
            {
                Category item = Repository.Read(id);

                result = new DetailsCategory()
                {
                    Id = item.Id,
                    Name = item.CategoryName
                };
            }

            return result;
        }

        public bool Exist(Expression<Func<Category, bool>> predicate)
        {
            return Repository.Exist(predicate);
        }

        public bool Exist(int id)
        {
            return Exist(item => item.Id == id);
        }

        public Pagination<DetailsCategory> Paginate(Paginator entry)
        {
            Pagination<DetailsCategory> result = new Pagination<DetailsCategory>()
            {
                TotalRecords = Repository.Read().Count(),
                PageIndex = entry.PageIndex
            };

            result.TotalPages = (int)Math.Ceiling(result.TotalRecords / (double)entry.PageSize);

            if (entry.PageIndex <= result.TotalPages)
            {
                int offset = entry.PageIndex > 1 ? (entry.PageIndex - 1) * entry.PageSize : 0;

                result.Records = Repository.Read()
                    .OrderBy(category => category.Id)
                    .Skip(offset)
                    .Take(entry.PageSize)
                    .Select(item => new DetailsCategory() { Id = item.Id, Name = item.CategoryName })
                    .ToList();
            }

            result.PageSize = result.Records.Count;

            return result;
        }

        public IQueryable<Category> Read()
        {
            return Repository.Read();
        }

        public DetailsCategory Update(int id, CreateCategory entry)
        {
            DetailsCategory result = null;

            if (Exist(id))
            {
                Category item = new Category()
                {
                    Id = id,
                    CategoryName = entry.Name
                };

                bool temporary = Repository.Edit(item);

                if (temporary)
                {
                    result = new DetailsCategory()
                    {
                        Id = item.Id,
                        Name = item.CategoryName
                    };
                }
            }

            return result;
        }
    }
}
