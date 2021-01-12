  using System;
  using Bookstore.Services.BookCatalog.Entities;
  using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services.BookCatalog.DbContexts
{
    public class BookCatalogDbContext : DbContext
    {
        public BookCatalogDbContext(DbContextOptions<BookCatalogDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var horrorGuid = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA314}");
            var fantasyGuid = Guid.Parse("{6900926A-AA18-4CF6-A62D-09ED26263D00}");
            var variousGuid = Guid.Parse("{8E6BC666-A459-4083-96EA-4654AFE99D83}");
            var scienceFictionGuid = Guid.Parse("{28B53FF0-0547-40C6-884C-9646CC4C3906}");
            var thrillerGuid = Guid.Parse("{5D1CD43D-5FF6-44DD-96D1-D06806795D02}");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = horrorGuid,
                Name = "Horror"
            });
            
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = fantasyGuid,
                Name = "Fantasy"
            });
            
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = variousGuid,
                Name = "Various"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = scienceFictionGuid,
                Name = "Science Fiction"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = thrillerGuid,
                Name = "Thriller"
            });

            modelBuilder.Entity<Author>().HasData(new Author()
            {
                Id = Guid.Parse("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                FirstName = "Stephen",
                LastName = "King",
                DateOfBirth = new DateTimeOffset(new DateTime(1947, 9, 21))
            },
            new Author()
            {
                Id = Guid.Parse("76053df4-6687-4353-8937-b45556748abe"),
                FirstName = "George",
                LastName = "RR Martin",
                DateOfBirth = new DateTimeOffset(new DateTime(1948, 9, 20)),
            },
            new Author()
            {
                Id = Guid.Parse("412c3012-d891-4f5e-9613-ff7aa63e6bb3"),
                FirstName = "Neil",
                LastName = "Gaiman",
                DateOfBirth = new DateTimeOffset(new DateTime(1960, 11, 10))
            },
            new Author()
            {
                Id = Guid.Parse("578359b7-1967-41d6-8b87-64ab7605587e"),
                FirstName = "Tom",
                LastName = "Lanoye",
                DateOfBirth = new DateTimeOffset(new DateTime(1958, 8, 27))
            },
            new Author()
            {
                Id = Guid.Parse("f74d6899-9ed2-4137-9876-66b070553f8f"),
                FirstName = "Douglas",
                LastName = "Adams",
                DateOfBirth = new DateTimeOffset(new DateTime(1952, 3, 11))
            },
            new Author()
            {
                Id = Guid.Parse("a1da1d8e-1988-4634-b538-a01709477b77"),
                FirstName = "Jens",
                LastName = "Lapidus",
                DateOfBirth = new DateTimeOffset(new DateTime(1974, 5, 24)),
            });

            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = Guid.Parse("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                    AuthorId = Guid.Parse("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    CategoryId = horrorGuid,
                    Title = "The Shining",
                    Description =
                        "The Shining is a horror novel by American author Stephen King. Published in 1977, it is King's third published novel and first hardback bestseller: the success of the book firmly established King as a preeminent author in the horror genre. "
                },
                new Book()
                {
                    Id = Guid.Parse("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
                    AuthorId = Guid.Parse("a1da1d8e-1988-4634-b538-a01709477b77"),
                    CategoryId = fantasyGuid,
                    Title = "Misery",
                    Description =
                        "Misery is a 1987 psychological horror novel by Stephen King. This novel was nominated for the World Fantasy Award for Best Novel in 1988, and was later made into a Hollywood film and an off-Broadway play of the same name."
                },
                new Book()
                {
                    Id = Guid.Parse("70a1f9b9-0a37-4c1a-99b1-c7709fc64167"),
                    AuthorId = Guid.Parse("a1da1d8e-1988-4634-b538-a01709477b77"),
                    CategoryId = scienceFictionGuid,
                    Title = "It",
                    Description =
                        "It is a 1986 horror novel by American author Stephen King. The story follows the exploits of seven children as they are terrorized by the eponymous being, which exploits the fears and phobias of its victims in order to disguise itself while hunting its prey. 'It' primarily appears in the form of a clown in order to attract its preferred prey of young children."
                },
                new Book()
                {
                    Id = Guid.Parse("60188a2b-2784-4fc4-8df8-8919ff838b0b"),
                    AuthorId = Guid.Parse("a1da1d8e-1988-4634-b538-a01709477b77"),
                    CategoryId = horrorGuid,
                    Title = "The Stand",
                    Description =
                        "The Stand is a post-apocalyptic horror/fantasy novel by American author Stephen King. It expands upon the scenario of his earlier short story 'Night Surf' and outlines the total breakdown of society after the accidental release of a strain of influenza that had been modified for biological warfare causes an apocalyptic pandemic which kills off the majority of the world's human population."
                },
                new Book()
                {
                    Id = Guid.Parse("447eb762-95e9-4c31-95e1-b20053fbe215"),
                    AuthorId = Guid.Parse("76053df4-6687-4353-8937-b45556748abe"),
                    CategoryId = fantasyGuid,
                    Title = "A Game of Thrones",
                    Description =
                        "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by American author George R. R. Martin. It was first published on August 1, 1996."
                },
                new Book()
                {
                    Id = Guid.Parse("bc4c35c3-3857-4250-9449-155fcf5109ec"),
                    AuthorId = Guid.Parse("76053df4-6687-4353-8937-b45556748abe"),
                    CategoryId = variousGuid,
                    Title = "The Winds of Winter",
                    Description = "Forthcoming 6th novel in A Song of Ice and Fire."
                },
                new Book()
                {
                    Id = Guid.Parse("09af5a52-9421-44e8-a2bb-a6b9ccbc8239"),
                    AuthorId = Guid.Parse("76053df4-6687-4353-8937-b45556748abe"),
                    CategoryId = fantasyGuid,
                    Title = "A Dance with Dragons",
                    Description =
                        "A Dance with Dragons is the fifth of seven planned novels in the epic fantasy series A Song of Ice and Fire by American author George R. R. Martin."
                },
                new Book()
                {
                    Id = Guid.Parse("9edf91ee-ab77-4521-a402-5f188bc0c577"),
                    AuthorId = Guid.Parse("412c3012-d891-4f5e-9613-ff7aa63e6bb3"),
                    CategoryId = fantasyGuid,
                    Title = "American Gods",
                    Description =
                        "American Gods is a Hugo and Nebula Award-winning novel by English author Neil Gaiman. The novel is a blend of Americana, fantasy, and various strands of ancient and modern mythology, all centering on the mysterious and taciturn Shadow."
                },
                new Book()
                {
                    Id = Guid.Parse("01457142-358f-495f-aafa-fb23de3d67e9"),
                    AuthorId = Guid.Parse("578359b7-1967-41d6-8b87-64ab7605587e"),
                    CategoryId = variousGuid,
                    Title = "Speechless",
                    Description =
                        "Good-natured and often humorous, Speechless is at times a 'song of curses', as Lanoye describes the conflicts with his beloved diva of a mother and her brave struggle with decline and death."
                },
                new Book()
                {
                    Id = Guid.Parse("e57b605f-8b3c-4089-b672-6ce9e6d6c23f"),
                    AuthorId = Guid.Parse("f74d6899-9ed2-4137-9876-66b070553f8f"),
                    CategoryId = scienceFictionGuid,
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    Description =
                        "The Hitchhiker's Guide to the Galaxy is the first of five books in the Hitchhiker's Guide to the Galaxy comedy science fiction 'trilogy' by Douglas Adams."
                },
                new Book()
                {
                    Id = Guid.Parse("1325360c-8253-473a-a20f-55c269c20407"),
                    AuthorId = Guid.Parse("a1da1d8e-1988-4634-b538-a01709477b77"),
                    CategoryId = variousGuid,
                    Title = "Easy Money",
                    Description =
                        "Easy Money or Snabba cash is a novel from 2006 by Jens Lapidus. It has been a success in term of sales, and the paperback was the fourth best seller of Swedish novels in 2007."
                }
            );
        }
    }
}
