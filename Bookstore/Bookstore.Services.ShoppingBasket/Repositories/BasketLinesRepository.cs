using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Services.ShoppingBasket.DbContexts;
using Bookstore.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Bookstore.Services.ShoppingBasket.Repositories
{
    public class BasketLinesRepository : IBasketLinesRepository
    {
        private readonly ShoppingBasketDbContext _shoppingBasketDbContext;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public BasketLinesRepository(ShoppingBasketDbContext shoppingBasketDbContext, 
            IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _shoppingBasketDbContext = shoppingBasketDbContext;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<BasketLine>> GetBasketLines(Guid basketId)
        {
            return await _shoppingBasketDbContext.BasketLines.Include(bl => bl.Book)
                .Where(b => b.BasketId == basketId).ToListAsync();
        }

        public async Task<BasketLine> GetBasketLineById(Guid basketLineId)
        {
            return await _shoppingBasketDbContext.BasketLines.Include(bl => bl.Book)
                .Where(b => b.BasketLineId == basketLineId).FirstOrDefaultAsync();
        }

        public async Task<BasketLine> AddOrUpdateBasketLine(Guid basketId, BasketLine basketLine)
        {
            var existingLine = await _shoppingBasketDbContext.BasketLines.Include(bl => bl.Book)
                .Where(b => b.BasketId == basketId && b.BookId == basketLine.BookId).FirstOrDefaultAsync();
            
            if (existingLine == null)
            {
                basketLine.BasketId = basketId;

                basketLine.Book = _shoppingBasketDbContext.Books
                    .FirstOrDefault(book => book.BookId == basketLine.BookId);
                _shoppingBasketDbContext.BasketLines.Add(basketLine);
                return basketLine;
            }

            existingLine.BookAmount += basketLine.BookAmount;
            UpdateBasketLine(existingLine);
            return existingLine;
        }

        public void UpdateBasketLine(BasketLine basketLine)
        {
            _shoppingBasketDbContext.BasketLines.Update(basketLine);
        }

        public  void RemoveBasketLine(BasketLine basketLine)
        {
            _shoppingBasketDbContext.BasketLines.Remove(basketLine);
            _bookRepository.RemoveBook(basketLine.Book);
            _authorRepository.RemoveAuthor(basketLine.Book.Author);
        }

        public async Task<bool> SaveChanges()
        {
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
    }
}