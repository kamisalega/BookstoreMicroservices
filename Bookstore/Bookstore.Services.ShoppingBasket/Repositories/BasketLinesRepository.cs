using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Services.ShoppingBasket.DbContexts;
using Bookstore.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services.ShoppingBasket.Repositories
{
    public class BasketLinesRepository  : IBasketLinesRepository
    {
        private readonly ShoppingBasketDbContext shoppingBasketDbContext;

        public BasketLinesRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
            this.shoppingBasketDbContext = shoppingBasketDbContext;
        }

        public async Task<IEnumerable<BasketLine>> GetBasketLines(Guid basketId)
        {
            return await shoppingBasketDbContext.BasketLines.Include(bl => bl.Book)
                .Where(b => b.BasketId == basketId).ToListAsync();
        }

        public async Task<BasketLine> GetBasketLineById(Guid basketLineId)
        {
            return await shoppingBasketDbContext.BasketLines.Include(bl => bl.Book)
                .Where(b => b.BasketLineId == basketLineId).FirstOrDefaultAsync();
        }

        public async Task<BasketLine> AddOrUpdateBasketLine(Guid basketId, BasketLine basketLine)
        {
            var existingLine = await shoppingBasketDbContext.BasketLines.Include(bl => bl.Book)
                .Where(b => b.BasketId == basketId && b.BookId == basketLine.BookId).FirstOrDefaultAsync();
            if (existingLine == null)
            {
                basketLine.BasketId = basketId;
                basketLine.Book =  shoppingBasketDbContext.Books
                    .FirstOrDefault(book => book.BookId == basketLine.BookId);
                shoppingBasketDbContext.BasketLines.Add(basketLine);
                return basketLine;
            }
            existingLine.BookAmount += basketLine.BookAmount;
            shoppingBasketDbContext.BasketLines.Update(existingLine);
            return existingLine;
        }

        public void UpdateBasketLine(BasketLine basketLine)
        {
            // empty on purpose
        }

        public void RemoveBasketLine(BasketLine basketLine)
        {
            shoppingBasketDbContext.BasketLines.Remove(basketLine);
        }

        public async Task<bool> SaveChanges()
        {
            return (await shoppingBasketDbContext.SaveChangesAsync() > 0);
        }
    }
}
