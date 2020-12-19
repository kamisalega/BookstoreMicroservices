using Bookstore.Services.BookCatalog.Entities;
using Bookstore.Services.BookCatalog.ResourceParameters;
using System;
using System.Collections.Generic;

namespace Bookstore.Services.BookCatalog.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthors();
        IEnumerable<Author> GetAuthors(AuthorsResourceParameters authorsResourceParameters);
        Author GetAuthor(Guid authorId);
        IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds);
        void AddAuthor(Author author);
        void DeleteAuthor(Author author);
        void UpdateAuthor(Author author);
        bool AuthorExists(Guid authorId);
    }
}
