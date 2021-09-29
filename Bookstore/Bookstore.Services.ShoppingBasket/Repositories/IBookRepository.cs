using System;
using System.Threading.Tasks;
using Bookstore.Services.BookCatalog.Entities;
using Book = Bookstore.Services.ShoppingBasket.Entities.Book;

namespace Bookstore.Services.ShoppingBasket.Repositories
{
    public interface IBookRepository
    {
        void AddBook(Book theBook);
        Task<bool> BookExists(Guid BookId);
        Task<bool> SaveChanges();
        void RemoveBook(Book book);
    }
}
