using AutoMapper;

namespace Bookstore.Services.ShoppingBasket.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Entities.Author, Models.Author>().ReverseMap();
        }
    }
}