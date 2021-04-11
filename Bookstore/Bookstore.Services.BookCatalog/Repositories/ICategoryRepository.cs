using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Services.BookCatalog.Entities;

namespace Bookstore.Services.BookCatalog.Services
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(Guid categoryId);
        IQueryable<Book> GetBooksByCategoryId(Guid categoryId);
    }
}
