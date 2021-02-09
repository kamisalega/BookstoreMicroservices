using System;
using AutoMapper;
using Bookstore.Services.BookCatalog.Models;
using Bookstore.Services.BookCatalog.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Services.BookCatalog.Entities;
using Bookstore.Services.BookCatalog.ViewModel;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        [Route("{categoryId}")]
        public async Task<ActionResult<PaginatedItemsViewModel<BookDto>>> BooksByCategoryIdAsync(
            Guid categoryId, [FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var books = _categoryRepository.GetBooksByCategoryId(categoryId);

            var totalBooks = await books
                .LongCountAsync();

            var booksOnPage = await books
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            var test = _mapper.Map<List<Models.BookDto>>(booksOnPage);

            //temsOnPage = ChangeUriPlaceholder(itemsOnPage);
            return new PaginatedItemsViewModel<BookDto>(pageSize, pageIndex, totalBooks, test);
        }
    }
}
