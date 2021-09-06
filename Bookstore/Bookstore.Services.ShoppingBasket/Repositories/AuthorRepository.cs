using System;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Services.ShoppingBasket.DbContexts;
using Bookstore.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services.ShoppingBasket.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ShoppingBasketDbContext _shoppingBasketDbContext;

        public AuthorRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
            _shoppingBasketDbContext = shoppingBasketDbContext;
        }
        public void RemoveAuthor(Author author)
        {
           _shoppingBasketDbContext.Authors.Remove(author);
        }

        public async Task<bool> AuthorExists(Guid authorId)
        {
            return await _shoppingBasketDbContext.Authors.AnyAsync(a => a.Id == authorId);
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