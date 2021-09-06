using System;

namespace Bookstore.Services.ShoppingBasket.Models
{
    public class BasketCheckout
    {
        public Guid BasketId { get; set; }

        //user info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressUser Address { get; set; }
        public Guid Buyer { get; set; }

        //payment information
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateTime CardExpiration { get; set; }
        public int CardSecurityNumber { get; set; }
        public int CardTypeId { get; set; }
        public string Expiration { get; set; }
        public double BasketTotal { get; set; }
        public string OrderNumber { get; set; }
    }
}
