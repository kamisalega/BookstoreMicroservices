using System;
using System.Collections.ObjectModel;

namespace Bookstore.Services.ShoppingBasket.Models
{
    public class Basket
    {
        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
        public Collection<BasketLine> BasketLines { get; set; }
        public int BookAmount { get; set; }
        public Guid? CouponId { get; set; }
    }
}
