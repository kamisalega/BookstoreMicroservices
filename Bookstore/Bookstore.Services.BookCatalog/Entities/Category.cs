using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Services.BookCatalog.Entities
{
    public class Category
    {
        [Required]
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
