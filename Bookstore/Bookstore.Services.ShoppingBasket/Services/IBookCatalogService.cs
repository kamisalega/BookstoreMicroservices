using System;
using System.Threading.Tasks;
using Bookstore.Services.ShoppingBasket.Entities;

namespace Bookstore.Services.ShoppingBasket.Services
{
    public interface IBookCatalogService
    {
        Task<Book> GetBook(Guid id);
    }
}
