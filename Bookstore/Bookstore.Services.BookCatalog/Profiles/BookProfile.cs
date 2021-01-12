using AutoMapper;
using Bookstore.Services.BookCatalog.Entities;

namespace Bookstore.Services.BookCatalog.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Entities.Book, Models.BookDto>()
                .ForMember(dest => dest.CategoryName, 
                    opts => opts.MapFrom(src => src.Category.Name));
            
        }
       
    }
}
