using System;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Services.ShoppingBasket.DbContexts;
using Bookstore.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services.ShoppingBasket.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ShoppingBasketDbContext _shoppingBasketDbContext;

        public BookRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
           _shoppingBasketDbContext = shoppingBasketDbContext;
        }

        public async Task<bool> BookExists(Guid bookId)
        {
            return await _shoppingBasketDbContext.Books.AnyAsync(e => e.BookId == bookId);
        }

        public void AddBook(Book book)
        {
            var author = _shoppingBasketDbContext.Authors.FirstOrDefault(a => a.Id == book.Author.Id);
            
            if (author != null)
                book.Author = author;
            
            
            _shoppingBasketDbContext.Books.Add(book);
        }

        public async Task<bool> SaveChanges()
        {
            _shoppingBasketDbContext.ChangeTracker.DetectChanges();
            foreach (var entry in _shoppingBasketDbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                entry.Property("LastModified").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = DateTime.Now;
                }
            }
            return (await _shoppingBasketDbContext.SaveChangesAsync() > 0);
        }

        public void RemoveBook(Book book)
        {
             _shoppingBasketDbContext.Books.Remove(book);
        }
    }
}
