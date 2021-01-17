using System;
using System.Collections.Generic;

namespace Bookstore.Services.BookCatalog.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
