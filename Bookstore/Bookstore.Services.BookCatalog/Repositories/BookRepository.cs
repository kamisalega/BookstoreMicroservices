using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Services.BookCatalog.Entities;

namespace Bookstore.Services.BookCatalog.Repositories
{
    public class BookRepository : IBookRepository
    {
        public Task<IEnumerable<Book>> GetBooks(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookById(Guid eventId)
        {
            throw new NotImplementedException();
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
    }
}
