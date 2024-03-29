using System;
using System.ComponentModel.DataAnnotations;
using Bookstore.Services.BookCatalog.Entities;

namespace Bookstore.Services.ShoppingBasket.Entities
{
    public class BasketLine
    {
        public Guid BasketLineId { get; set; }

        [Required]
        public Guid BasketId { get; set; }

        [Required]
        public Guid BookId { get; set; }

        public Book Book { get; set; }

        [Required]
        public int BookAmount { get; set; }

        [Required]
        public double Price { get; set; }

        public Basket Basket { get; set; }
    }
}
