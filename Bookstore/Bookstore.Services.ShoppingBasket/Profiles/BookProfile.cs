using AutoMapper;

namespace Bookstore.Services.ShoppingBasket.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Entities.Book, Models.Book>().ReverseMap();

        }
    }
}
