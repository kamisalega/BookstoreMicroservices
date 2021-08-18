using System;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Services.ShoppingBasket.Entities
{
    public class Author
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
    }
}