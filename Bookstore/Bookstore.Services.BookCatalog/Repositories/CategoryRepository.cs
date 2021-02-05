using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Services.BookCatalog.DbContexts;
using Bookstore.Services.BookCatalog.Entities;
using Bookstore.Services.BookCatalog.Services;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services.BookCatalog.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookCatalogDbContext _bookCatalogDbContext;

        public CategoryRepository(BookCatalogDbContext bookCatalogDbContext)
        {
            _bookCatalogDbContext = bookCatalogDbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _bookCatalogDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(string categoryId)
        {
            return await _bookCatalogDbContext.Categories.Where(x => x.CategoryId.ToString() == categoryId).FirstOrDefaultAsync();
        }
    }
}
