using AutoMapper;
using Bookstore.Services.BookCatalog.Models;
using Bookstore.Services.BookCatalog.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Services.BookCatalog.Controllers
{
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            var result = await _categoryRepository.GetAllCategories();
            return Ok(_mapper.Map<List<CategoryDto>>(result));
        }
    }
}
