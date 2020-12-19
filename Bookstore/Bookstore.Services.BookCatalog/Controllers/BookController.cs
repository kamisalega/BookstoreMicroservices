using AutoMapper;
using Bookstore.Services.BookCatalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<Models.BookDto>>> Get(
            [FromQuery] Guid categoryId)
        {
            var result = await _bookRepository.GetBooks(categoryId);
            return Ok(_mapper.Map<List<Models.BookDto>>(result));
        }

        [HttpGet("bookId}")]
        public async Task<ActionResult<Models.BookDto>> GetById(Guid bookId)
        {
            var result = await _bookRepository.GetBookById(bookId);
            return Ok(_mapper.Map<Models.BookDto>(result));
        }
    }
}
