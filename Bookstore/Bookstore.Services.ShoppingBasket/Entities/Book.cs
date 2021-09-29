using System;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Services.ShoppingBasket.Entities
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        
        public string ImageUrl { get; set; }
        
        public double Price { get; set; }
        
        [Required]
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
