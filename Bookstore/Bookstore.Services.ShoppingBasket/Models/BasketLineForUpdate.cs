using System.ComponentModel.DataAnnotations;

namespace Bookstore.Services.ShoppingBasket.Models
{
    public class BasketLineForUpdate
    {
        [Required]
        public int TicketAmount { get; set; }
    }
}
