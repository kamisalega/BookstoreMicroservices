using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.Services.Marketing.Entities;

namespace Bookstore.Services.Marketing.Services
{
    public interface IBasketChangeBookService
    {
        Task<List<BasketChangeBook>> GetBasketChangeBooks(DateTime startDate, int max);
    }
}
