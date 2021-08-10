using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.Services.ShoppingBasket.Entities;
using Bookstore.Services.ShoppingBasket.Entities.Enum;
using Bookstore.Services.ShoppingBasket.Models;
using Bookstore.Services.ShoppingBasket.Repositories;
using Bookstore.Services.ShoppingBasket.Services;
using Microsoft.AspNetCore.Mvc;
using BasketLine = Bookstore.Services.ShoppingBasket.Models.BasketLine;

namespace Bookstore.Services.ShoppingBasket.Controllers
{
    [ApiController]
    [Route("api/baskets/{basketId}/basketlines")]
    public class BasketLinesController : ControllerBase
    {
        private readonly IBasketRepository basketRepository;
        private readonly IBasketLinesRepository basketLinesRepository;
        private readonly IBookRepository bookRepository;
        private readonly IBookCatalogService bookCatalogService;
        private readonly IMapper mapper;
        private readonly IBasketChangeBookRepository basketChangeBookRepository;

        public BasketLinesController(IBasketRepository basketRepository,
            IBasketLinesRepository basketLinesRepository, IBookRepository bookRepository,
            IBookCatalogService bookCatalogService, IMapper mapper, IBasketChangeBookRepository basketChangeBookRepository)
        {
            this.basketRepository = basketRepository;
            this.basketLinesRepository = basketLinesRepository;
            this.bookRepository = bookRepository;
            this.bookCatalogService = bookCatalogService;
            this.basketChangeBookRepository = basketChangeBookRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketLine>>> Get(Guid basketId)
        {
            if (!await basketRepository.BasketExists(basketId))
            {
                return NotFound();
            }

            var basketLines = await basketLinesRepository.GetBasketLines(basketId);
            return Ok(mapper.Map<IEnumerable<BasketLine>>(basketLines));
        }

        [HttpGet("{basketLineId}", Name = "GetBasketLine")]
        public async Task<ActionResult<BasketLine>> Get(Guid basketId, Guid basketLineId)
        {
            if (!await basketRepository.BasketExists(basketId))
            {
                return NotFound();
            }

            var basketLine = await basketLinesRepository.GetBasketLineById(basketLineId);
            if (basketLine == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<BasketLine>(basketLine));
        }

        [HttpPost]
        public async Task<ActionResult<BasketLine>> Post(Guid basketId, [FromBody] BasketLineForCreation basketLineForCreation)
        {
            var basket = await basketRepository.GetBasketById(basketId);

            if (basket == null)
            {
                return NotFound();
            }

            if (!await bookRepository.BookExists(basketLineForCreation.BookId))
            {
                var bookFromCatalog = await bookCatalogService.GetBook(basketLineForCreation.BookId);
                bookFromCatalog.BookId = basketLineForCreation.BookId;
                bookRepository.AddBook(bookFromCatalog);
                await bookRepository.SaveChanges();
            }

            var basketLineEntity = mapper.Map<Entities.BasketLine>(basketLineForCreation);

            var processedBasketLine = await basketLinesRepository.AddOrUpdateBasketLine(basketId, basketLineEntity);
            await basketLinesRepository.SaveChanges();

            var basketLineToReturn = mapper.Map<BasketLine>(processedBasketLine);

            //log also to the book repo
            BasketChangeBook basketChangeBook = new BasketChangeBook
            {
                BasketChangeType = BasketChangeTypeEnum.Add,
                BookId = basketLineForCreation.BookId,
                InsertedAt = DateTime.Now,
                UserId = basket.UserId
            };
            await basketChangeBookRepository.AddBasketBook(basketChangeBook);

            return CreatedAtRoute(
                "GetBasketLine",
                new { basketId = basketLineEntity.BasketId, basketLineId = basketLineEntity.BasketLineId },
                basketLineToReturn);
        }

        [HttpPut("{basketLineId}")]
        public async Task<ActionResult<BasketLine>> Put(Guid basketId,
            Guid basketLineId,
            [FromBody] BasketLineForUpdate basketLineForUpdate)
        {
            if (!await basketRepository.BasketExists(basketId))
            {
                return NotFound();
            }

            var basketLineEntity = await basketLinesRepository.GetBasketLineById(basketLineId);

            if (basketLineEntity == null)
            {
                return NotFound();
            }

            // map the entity to a dto
            // apply the updated field values to that dto
            // map the dto back to an entity
            mapper.Map(basketLineForUpdate, basketLineEntity);

            basketLinesRepository.UpdateBasketLine(basketLineEntity);
            await basketLinesRepository.SaveChanges();

            return Ok(mapper.Map<BasketLine>(basketLineEntity));
        }

        [HttpDelete("{basketLineId}")]
        public async Task<IActionResult> Delete(Guid basketId, Guid basketLineId)
        {
            //if (!await basketRepository.BasketExists(basketId))
            //{
            //    return NotFound();
            //}

            var basket = await basketRepository.GetBasketById(basketId);

            if (basket == null)
            {
                return NotFound();
            }

            var basketLineEntity = await basketLinesRepository.GetBasketLineById(basketLineId);

            if (basketLineEntity == null)
            {
                return NotFound();
            }

            basketLinesRepository.RemoveBasketLine(basketLineEntity);
            await basketLinesRepository.SaveChanges();

            //publish removal book
            BasketChangeBook basketChangeBook = new BasketChangeBook
            {
                BasketChangeType = BasketChangeTypeEnum.Remove,
                BookId = basketLineEntity.BookId,
                InsertedAt = DateTime.Now,
                UserId = basket.UserId
            };
            await basketChangeBookRepository.AddBasketBook(basketChangeBook);

            return NoContent();
        }
    }
}
