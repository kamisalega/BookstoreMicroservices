using System;
using Bookstore.Services.Marketing.Models.Models;

namespace Bookstore.Services.Marketing.Entities
{
    public class BasketChangeBook
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTimeOffset InsertedAt { get; set; }
        public BasketChangeTypeEnum BasketChangeType { get; set; }
    }
}
