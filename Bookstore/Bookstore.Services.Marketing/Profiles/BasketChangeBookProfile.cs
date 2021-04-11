using AutoMapper;

namespace Bookstore.Services.Marketing.Profiles
{
    public class BasketChangeBookProfile : Profile
    {
        public BasketChangeBookProfile()
        {
            CreateMap<Models.BasketChangeBook, Entities.BasketChangeBook>();
        }
    }
}
