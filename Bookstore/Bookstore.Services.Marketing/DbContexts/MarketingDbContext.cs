using Bookstore.Services.Marketing.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services.Marketing.DbContexts
{
    public class MarketingDbContext :  DbContext
    {
        public MarketingDbContext(DbContextOptions<MarketingDbContext> options)
            : base(options)
        {
        }

        public DbSet<BasketChangeBook> BasketChangeBooks { get; set; }
    }
}
