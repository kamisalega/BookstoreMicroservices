using System;
using System.Threading.Tasks;
using Bookstore.Services.ShoppingBasket.DbContexts;
using Bookstore.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services.ShoppingBasket.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ShoppingBasketDbContext shoppingBasketDbContext;

        public BookRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
            this.shoppingBasketDbContext = shoppingBasketDbContext;
        }

        public async Task<bool> BookExists(Guid bookId)
        {
            return await shoppingBasketDbContext.Books.AnyAsync(e => e.BookId == bookId);
        }

        public void AddBook(Book theBook)
        {
            shoppingBasketDbContext.Books.Add(theBook);
        }

        public async Task<bool> SaveChanges()
        {
            return (await shoppingBasketDbContext.SaveChangesAsync() > 0);
        }
    }
}
