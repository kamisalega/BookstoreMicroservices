using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Services.ShoppingBasket.DbContexts;
using Bookstore.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services.ShoppingBasket.Repositories
{
    public class BasketChangeBookRepository : IBasketChangeBookRepository
    {
        private readonly ShoppingBasketDbContext shoppingBasketDbContext;

        public BasketChangeBookRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
            this.shoppingBasketDbContext = shoppingBasketDbContext;
        }

        public async Task AddBasketBook(BasketChangeBook basketChangeBook)
        {
            await shoppingBasketDbContext.BasketChangeBooks.AddAsync(basketChangeBook);
            await shoppingBasketDbContext.SaveChangesAsync();
        }

        public async Task<List<BasketChangeBook>> GetBasketChangeBooks(DateTime startDate, int max)
        {
            if (max != 0)
            {
                return await shoppingBasketDbContext.BasketChangeBooks.ToListAsync();
            }

            return new List<BasketChangeBook>();

            // .Where(b => b.InsertedAt > startDate)
            // .OrderBy(b => b.InsertedAt).Take(max);
        }
    }
}
