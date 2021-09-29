using System;
using System.Collections.ObjectModel;

namespace Bookstore.Services.ShoppingBasket.Models
{
    public class BasketForUpdating
    {
        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
        public Collection<BasketLine> BasketLines { get; set; }
        public int BookAmount { get; set; }
        public Guid? CouponId { get; set; }
    }
}