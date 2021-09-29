using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Bookstore.Integration.Messages;

namespace Bookstore.Services.ShoppingBasket.Messages
{
    public class BasketCheckoutMessage : IntegrationBaseMessage
    {
        public Guid BasketId { get; set; }

        //user info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressMessage Address { get; set; }
        public Guid UserId { get; set; }


        //payment information
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateTime CardExpiration { get; set; }
        public int CardSecurityNumber { get; set; }
        public int CardTypeId { get; set; }
        public string Expiration { get; set; }
        public double BasketTotal { get; set; }
        public string OrderNumber { get; set; }

        //order info
        public List<BasketLineMessage> BasketLines { get; set; }
    }
}
