using System;
using Bookstore.Services.BookCatalog.Entities;
using Bookstore.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;
using Bookstore.Services.ShoppingBasket.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Author = Bookstore.Services.ShoppingBasket.Entities.Author;
using Book = Bookstore.Services.ShoppingBasket.Entities.Book;

namespace Bookstore.Services.ShoppingBasket.DbContexts
{
    public class ShoppingBasketDbContext : DbContext
    {
        
        public ShoppingBasketDbContext(DbContextOptions<ShoppingBasketDbContext> options)
            : base(options)
        {
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketLine> BasketLines { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BasketChangeBook> BasketChangeBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("Created").HasDefaultValue(DateTime.Now);
                modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModified").HasDefaultValue(DateTime.Now);
            }

     //        modelBuilder.Entity<Book>().HasData
     //        (
     //            new Book()
     //            {
     //                BookId = Guid.Parse("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
     //                Title = "The Shining",
     //                Date = DateTime.Now.AddMonths(1),
     //            },
     //            new Book()
     //            {
     //                BookId = Guid.Parse("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
     //                Title = "Misery",
     //                Date = DateTime.Now.AddMonths(2),
     //            },
     //            new Book()
     //            {
     //                BookId = Guid.Parse("70a1f9b9-0a37-4c1a-99b1-c7709fc64167"),
     //                Title = "It",
     //                Date = DateTime.Now.AddMonths(3)
     //            },
     //            new Book()
     //            {
     //                BookId = Guid.Parse("60188a2b-2784-4fc4-8df8-8919ff838b0b"),
     //                Title = "The Stand",
     //                Date = DateTime.Now.AddMonths(4)
     //            },
     //            new Book()
     //            {
     //                BookId = Guid.Parse("447eb762-95e9-4c31-95e1-b20053fbe215"),
     //                Title = "A Game of Thrones",
     //                Date = DateTime.Now.AddMonths(5)
     //            },
     //            new Book()
     //            {
     //                BookId = Guid.Parse("bc4c35c3-3857-4250-9449-155fcf5109ec"),
     //                Title = "The Winds of Winter",
     //                Date = DateTime.Now.AddMonths(6)
     //            },
     //            new Book()
     //            {
     //                BookId = Guid.Parse("09af5a52-9421-44e8-a2bb-a6b9ccbc8239"),
     //                Title = "A Dance with Dragons",
     //                Date = DateTime.Now.AddMonths(7),
     //            },
     //            new Book()
     //            {
     //                BookId = Guid.Parse("9edf91ee-ab77-4521-a402-5f188bc0c577"),
     //                Title = "American Gods",
     //                Date = DateTime.Now.AddMonths(8),
     //            },
     //            new Book()
     //            {
     //                BookId = Guid.Parse("01457142-358f-495f-aafa-fb23de3d67e9"),
     //                Title = "Speechless",
     //
     //                Date = DateTime.Now.AddMonths(9),
     //            },
     //            new Book()
     //            {
     //                BookId = Guid.Parse("e57b605f-8b3c-4089-b672-6ce9e6d6c23f"),
     //                Title = "The Hitchhiker's Guide to the Galaxy",
     //                Date = DateTime.Now.AddMonths(10),
     //            },
     //            new Book()
     //            {
     //                BookId = Guid.Parse("1325360c-8253-473a-a20f-55c269c20407"),
     //                Title = "Easy Money",
     //                Date = DateTime.Now.AddMonths(11),
     // }
     //        );

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
