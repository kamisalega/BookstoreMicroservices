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
        
        public async Task<bool> SaveChanges()
        {
            var timesmap = DateTime.Now;
            foreach (var entry in shoppingBasketDbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                entry.Property("LastModified").CurrentValue = timesmap;

                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = timesmap;
                }
            }

            return (await shoppingBasketDbContext.SaveChangesAsync() > 0);
        }
    }
}
