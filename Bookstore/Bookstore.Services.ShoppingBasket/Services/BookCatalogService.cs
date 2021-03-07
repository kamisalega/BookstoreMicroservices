using System;
using System.Net.Http;
using System.Threading.Tasks;
using Bookstore.Services.ShoppingBasket.Entities;
using Bookstore.Services.ShoppingBasket.Extensions;

namespace Bookstore.Services.ShoppingBasket.Services
{
    public class BookCatalogService : IBookCatalogService
    {
        private readonly HttpClient client;

        public BookCatalogService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Book> GetBook(Guid id)
        {
            var response = await client.GetAsync($"/api/books/{id}");
            return await response.ReadContentAs<Book>();
        }
    }
}
