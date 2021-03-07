using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.Services.ShoppingBasket.Models;
using Bookstore.Services.ShoppingBasket.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Services.ShoppingBasket.Controllers
{
    [ApiController]
    [Route("api/basketbook")]
    public class BasketChangeBookController : Controller
    {
        private readonly IBasketChangeBookRepository basketChangeBookRepository;
        private readonly IMapper mapper;

        public BasketChangeBookController(IMapper mapper, IBasketChangeBookRepository basketChangeBookRepository)
        {
            this.mapper = mapper;
            this.basketChangeBookRepository = basketChangeBookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] DateTime fromDate, [FromQuery] int max)
        {
            var books = await basketChangeBookRepository.GetBasketChangeBooks(fromDate, max);
            if (books != null)
            {
                return BadRequest("");
            }

            return  Ok(mapper.Map<List<BasketChangeBookForPublication>>(books));;
        }
    }
}
