using System;

namespace Bookstore.Services.ShoppingBasket.Messages
{
    public class BasketLineMessage
    {
        public Guid BasketLineId { get; set; }
        public double Price { get; set; }
        public int BookAmount { get; set; }
    }
}
