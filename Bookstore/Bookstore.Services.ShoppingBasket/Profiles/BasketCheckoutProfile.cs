using AutoMapper;
using Bookstore.Services.ShoppingBasket.Messages;
using Bookstore.Services.ShoppingBasket.Models;

namespace Bookstore.Services.ShoppingBasket.Profiles
{
    public class BasketCheckoutProfile : Profile
    {
        public BasketCheckoutProfile()
        {
            CreateMap<AddressUser, AddressMessage>().ReverseMap();
            CreateMap<BasketCheckout, BasketCheckoutMessage>().ReverseMap();

        }
    }
}
