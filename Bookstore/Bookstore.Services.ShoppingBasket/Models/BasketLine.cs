using System;

namespace Bookstore.Services.ShoppingBasket.Models
{
    public class BasketLine
    {
        public Guid BasketLineId { get; set; }
        public Guid BasketId { get; set; }
        public Guid BookId { get; set; }
        public double Price { get; set; }
        public int BookAmount { get; set; }
        public Book Book { get; set; }
    }
}
