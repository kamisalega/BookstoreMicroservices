using System;

namespace Bookstore.Services.BookCatalog.Models
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
