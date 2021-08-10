using System;
using System.ComponentModel.DataAnnotations;
using Bookstore.Services.ShoppingBasket.Entities;

namespace Bookstore.Services.ShoppingBasket.Models
{
    public class BasketLineForCreation
    {
        [Required]
        public Guid BookId { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int BookAmount { get; set; }
    }
}
