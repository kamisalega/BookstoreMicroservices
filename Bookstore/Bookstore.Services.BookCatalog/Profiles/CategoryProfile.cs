using AutoMapper;
using Bookstore.Services.BookCatalog.Entities;

namespace Bookstore.Services.BookCatalog.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entities.Category, Models.CategoryDto>().ReverseMap();
            CreateMap<Entities.Category, Category>().ReverseMap();
        }
    }
}
