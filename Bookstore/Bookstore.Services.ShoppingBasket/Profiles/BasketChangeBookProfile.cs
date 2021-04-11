using AutoMapper;
using Bookstore.Services.ShoppingBasket.Entities;
using Bookstore.Services.ShoppingBasket.Models;

namespace Bookstore.Services.ShoppingBasket.Profiles
{
    public class BasketChangeBookProfile : Profile
    {
        public BasketChangeBookProfile()
        {
            CreateMap<BasketChangeBook, BasketChangeBookForPublication>().ReverseMap();
        }
    }
}
