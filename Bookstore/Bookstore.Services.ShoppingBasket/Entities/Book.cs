using System;

namespace Bookstore.Services.ShoppingBasket.Entities
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}
