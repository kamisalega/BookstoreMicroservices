using System;
using Bookstore.Services.BookCatalog.Entities;

namespace Bookstore.Services.ShoppingBasket.Models
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public Author Author { get; set; }
    }
}