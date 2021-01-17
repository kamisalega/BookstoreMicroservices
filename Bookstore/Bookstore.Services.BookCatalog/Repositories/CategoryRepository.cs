using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Services.BookCatalog.Entities;
using Bookstore.Services.BookCatalog.Services;

namespace Bookstore.Services.BookCatalog.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryById(string categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
