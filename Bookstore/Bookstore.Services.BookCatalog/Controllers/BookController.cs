using AutoMapper;
using Bookstore.Services.BookCatalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.Services.BookCatalog.Models;
using Bookstore.Services.BookCatalog.ViewModel;

namespace Bookstore.Services.BookCatalog.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> Get([FromQuery] Guid categoryId,
            [FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var totalCountBooks = await _bookRepository.GetTotalCountBooks();
            var result = await _bookRepository.GetBooks(categoryId, pageSize, pageIndex);

            var booksOnPage = _mapper.Map<List<Models.BookDto>>(result);
            var model = new PaginatedItemsViewModel<Models.BookDto>(pageSize, pageIndex, totalCountBooks, booksOnPage);

            return Ok(model);
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<Models.BookDto>> GetById(Guid bookId)
        {
            var result = await _bookRepository.GetBookById(bookId);
            var booksOnPage = _mapper.Map<Models.BookDto>(result);
            return Ok(booksOnPage);
        }
    }
}
