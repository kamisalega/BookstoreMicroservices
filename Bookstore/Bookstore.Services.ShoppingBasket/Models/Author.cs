using System;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Services.ShoppingBasket.Models
{
    public class Author
    {
        [Required]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public DateTimeOffset? DateOfDeath { get; set; }
    }
}