using System;
using System.Threading.Tasks;
using Bookstore.Services.ShoppingBasket.Entities;

namespace Bookstore.Services.ShoppingBasket.Repositories
{
    public interface IAuthorRepository
    {
        void RemoveAuthor(Author author);
        Task<bool> AuthorExists(Guid authorId);
        Task<bool> SaveChanges();
    }
}