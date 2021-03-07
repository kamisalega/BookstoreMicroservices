using System;
using System.Threading.Tasks;
using Bookstore.Services.ShoppingBasket.Models;

namespace Bookstore.Services.ShoppingBasket.Services
{
    public interface IDiscountService
    {
        Task<Coupon> GetCoupon(Guid couponId);
        Task<Coupon> GetCouponWithError(Guid couponId);
    }
}
