using Bookstore.Services.BookCatalog.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Services.BookCatalog.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks(Guid categoryId);
        Task<Book> GetBookById(Guid bookId);
        Book GetBook(Guid authorId, Guid bookId);
        void AddBook(Guid authorId, Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
