using System;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Services.BookCatalog.Entities
{
    public class Book
    {
        [Required]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public Author Author { get; set; }
        public DateTime Date { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
