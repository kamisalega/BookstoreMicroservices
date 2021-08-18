using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Services.BookCatalog.DbContexts;
using Bookstore.Services.BookCatalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services.BookCatalog.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookCatalogDbContext _bookCatalogDbContext;

        public BookRepository(BookCatalogDbContext bookCatalogDbContext)
        {
            _bookCatalogDbContext = bookCatalogDbContext;
        }

        public async Task<IEnumerable<Book>> GetBooks(Guid categoryId, int pageSize, int pageIndex)
        {
            return await _bookCatalogDbContext.Books
                .Include(x => x.Category)
                .Include(x => x.Author)
                .Where(x => (x.CategoryId == categoryId || categoryId == Guid.Empty))
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();
        }


        public async Task<Book> GetBookById(Guid bookId)
        {
            return await _bookCatalogDbContext.Books
                .Include(catalog => catalog.Category)
                .Include(catalog => catalog.Author)
                .Where(x => x.Id == bookId).FirstOrDefaultAsync();
        }

        public Book GetBook(Guid authorId, Guid bookId)
        {
            throw new NotImplementedException();
        }

        public void AddBook(Guid authorId, Book book)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task<long> GetTotalCountBooks()
        {
            return await _bookCatalogDbContext.Books.LongCountAsync();
        }
    }
}
