using System.Threading.Tasks;
using Bookstore.Services.Marketing.DbContexts;
using Bookstore.Services.Marketing.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services.Marketing.Repositories
{
    public class BasketChangeBookRepository : IBasketChangeBookRepository
    {
        private readonly DbContextOptions<MarketingDbContext> dbContextOptions;

        public BasketChangeBookRepository(DbContextOptions<MarketingDbContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public async Task AddBasketChangeBook(BasketChangeBook basketChangeBook)
        {
            await using (var marketingDbContext = new MarketingDbContext(dbContextOptions))
            {
                await marketingDbContext.BasketChangeBooks.AddAsync(basketChangeBook);
                await marketingDbContext.SaveChangesAsync();
            }
        }
    }
}
