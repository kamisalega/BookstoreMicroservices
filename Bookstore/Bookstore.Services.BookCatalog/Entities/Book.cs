﻿using System;

namespace Bookstore.Services.BookCatalog.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
    }
}
