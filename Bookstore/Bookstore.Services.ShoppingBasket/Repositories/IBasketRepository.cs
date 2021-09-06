using System;
using System.Threading.Tasks;
using Bookstore.Services.ShoppingBasket.Entities;

namespace Bookstore.Services.ShoppingBasket.Repositories
{
    public interface IBasketRepository
    {
        Task<bool> BasketExists(Guid basketId);

        Task<Basket> GetBasketById(Guid basketId);
        Task<Basket> GetBasketByUserId(Guid userId);

        void AddBasket(Basket basket);

        Task<bool> SaveChanges();

        Task ClearBasket(Guid basketId);
    }
}