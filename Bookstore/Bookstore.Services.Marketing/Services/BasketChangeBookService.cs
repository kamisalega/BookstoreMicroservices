using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Bookstore.Services.Marketing.Entities;
using Bookstore.Services.Marketing.Extensions;

namespace Bookstore.Services.Marketing.Services
{
    public class BasketChangeBookService : IBasketChangeBookService
    {
        private readonly HttpClient client;
        public BasketChangeBookService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<List<BasketChangeBook>> GetBasketChangeBooks(DateTime startDate, int max)
        {
            var formattedDate = $"{startDate.Year}/{startDate.Month}/{startDate.Day} {startDate.Hour}:{startDate.Minute}:{startDate.Second}";
            var s = $"/api/basketBook?fromDate={formattedDate}&max={max}";
            var response = await client.GetAsync(s);
            return await response.ReadContentAs<List<BasketChangeBook>>();
        }
    }
}
