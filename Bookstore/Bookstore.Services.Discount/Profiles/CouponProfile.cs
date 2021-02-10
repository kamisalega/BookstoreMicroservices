using AutoMapper;
using Bookstore.Services.Discount.Entities;
using Bookstore.Services.Discount.Models;

namespace Bookstore.Services.Discount.Profiles
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<Coupon, CouponDto>().ReverseMap();
        }
    }
}
