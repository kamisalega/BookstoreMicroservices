using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.Services.ShoppingBasket.Entities;

namespace Bookstore.Services.ShoppingBasket.Repositories
{
    public interface IBasketChangeBookRepository
    {
        Task AddBasketBook(BasketChangeBook basketChangeBook);
        Task<List<BasketChangeBook>> GetBasketChangeBooks(DateTime startDate, int max);
    }
}
