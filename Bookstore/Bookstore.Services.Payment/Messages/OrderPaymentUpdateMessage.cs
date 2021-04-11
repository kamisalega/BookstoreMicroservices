using System;
using Bookstore.Integration.Messages;

namespace Bookstore.Services.Payment.Messages
{
    public class OrderPaymentUpdateMessage : IntegrationBaseMessage
    {
        public Guid OrderId { get; set; }
        public int Total { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardExpiration { get; set; }
        public bool PaymentSuccess { get; set; }
    }
}
