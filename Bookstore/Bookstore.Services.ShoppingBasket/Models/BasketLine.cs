using System;
using Bookstore.Services.ShoppingBasket.Entities;

namespace Bookstore.Services.ShoppingBasket.Models
{
    public class BasketLine
    {
        public Guid BasketLineId { get; set; }
        public Guid BasketId { get; set; }
        public Guid BookId { get; set; }
        public int Price { get; set; }
        public int TicketAmount { get; set; }
        public Book Book { get; set; }
    }
}
