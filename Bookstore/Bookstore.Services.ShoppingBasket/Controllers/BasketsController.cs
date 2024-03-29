using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.Integration.MessagingBus;
using Bookstore.Services.ShoppingBasket.Messages;
using Bookstore.Services.ShoppingBasket.Models;
using Bookstore.Services.ShoppingBasket.Repositories;
using Bookstore.Services.ShoppingBasket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Bookstore.Services.ShoppingBasket.Controllers
{
    [ApiController]
    [Route("api/baskets")]
    public class BasketsController : ControllerBase
    {
         private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;
        private readonly IMessageBus messageBus;
        private readonly IDiscountService discountService;

        public BasketsController(IBasketRepository basketRepository, 
            IMapper mapper, 
            IMessageBus messageBus, 
            IDiscountService discountService)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
            this.messageBus = messageBus;
            this.discountService = discountService;
        }

        [HttpGet("{basketId}", Name = "GetBasket")]
        public async Task<ActionResult<Basket>> Get(Guid basketId)
        {
            var basket = await basketRepository.GetBasketById(basketId);
            
            if (basket == null)
            {
                return NotFound();
            }

            var result = mapper.Map<Basket>(basket);
            result.BookAmount = basket.BasketLines.Sum(bl => bl.BookAmount);
            return Ok(result);
        }
        
        [HttpGet("{userId}/userbasket")]
        public async Task<ActionResult<Basket>> GetBasketByUserId(Guid userId)
        {
            var basket = await basketRepository.GetBasketByUserId(userId);
            
            if (basket == null)
            {
                return NotFound();
            }

            var result = mapper.Map<Basket>(basket);
            result.BookAmount = basket.BasketLines.Sum(bl => bl.BookAmount);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Basket>> AddBasketAsync(BasketForCreation basketForCreation)
        {
            var basketEntity = await basketRepository.GetBasketByUserId(basketForCreation.UserId);

            if (basketEntity == null)
            {
                basketEntity = mapper.Map<Entities.Basket>(basketForCreation);
                basketRepository.AddBasket(basketEntity);
                await basketRepository.SaveChanges();
            }

            var basketToReturn = mapper.Map<Basket>(basketEntity);

            return Created(
                $"/api/baskets/{basketEntity.BasketId}",
                basketToReturn);

            // return Ok(basketToReturn);
        }
        
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Basket),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<Basket>> UpdateAllBasketAsync(BasketForUpdating basketForUpdating)
        {
            if (basketForUpdating.BasketLines == null || !basketForUpdating.BasketLines.Any())
            {
                return BadRequest("Need to pass at least one basket line");
            }
        
            var basketEntity = await basketRepository.GetBasketById(basketForUpdating.BasketId); 
        
            if (basketEntity == null)
            {
                basketEntity = mapper.Map<Entities.Basket>(basketForUpdating);
                basketRepository.AddBasket(basketEntity);
                await basketRepository.SaveChanges();
            }
        
            var bookCalculated = basketForUpdating.BasketLines.GroupBy(x => x.BookId, x => x,
                (k, i) => new { BookId = k, Books = i }).Select(groupedBook =>
            {
                var book = groupedBook.Books.First();
                book.BookAmount = groupedBook.Books.Sum(i => i.BookAmount);
                return book;
            });
        
            var basketToReturn = mapper.Map<Basket>(basketEntity);
        
            return basketToReturn;
        
        }

        
        [HttpPut("{basketId}/coupon")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ApplyCouponToBasket(Guid basketId, Coupon coupon)
        {
            var basket = await basketRepository.GetBasketById(basketId);

            if (basket == null)
            {
                return BadRequest();
            }

            basket.CouponId = coupon.CouponId;
            await basketRepository.SaveChanges();

            return Accepted();
        }

        [HttpPost("checkout")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CheckoutBasketAsync([FromBody] BasketCheckout basketCheckout)
        {
            try
            {
                //based on basket checkout, fetch the basket lines from repo
                var basket = await basketRepository.GetBasketById(basketCheckout.BasketId);

                if (basket == null)
                {
                    return BadRequest();
                }

                BasketCheckoutMessage basketCheckoutMessage = mapper.Map<BasketCheckoutMessage>(basketCheckout);
                basketCheckoutMessage.BasketLines = new List<BasketLineMessage>();
                double total = 0;

                foreach (var b in basket.BasketLines)
                {
                    var basketLineMessage = new BasketLineMessage
                    {
                        BasketLineId = b.BasketLineId,
                        Price = b.Price,
                        BookAmount = b.BookAmount
                    };

                    total += b.Price * b.BookAmount;

                    basketCheckoutMessage.BasketLines.Add(basketLineMessage);
                }

                //apply discountt by talking to the discount service
                Coupon coupon = null;

                if (basket.CouponId.HasValue)
                    coupon = await discountService.GetCoupon(basket.CouponId.Value);
                //
                //if (basket.CouponId.HasValue)
                //    coupon = await discountService.GetCouponWithError(basket.CouponId.Value);

                if (coupon != null)
                {
                    basketCheckoutMessage.BasketTotal = total - coupon.Amount;
                }
                else
                {
                    basketCheckoutMessage.BasketTotal = total;
                }

                try
                {
                    await messageBus.PublishMessage(basketCheckoutMessage, "checkoutmessage");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                await basketRepository.ClearBasket(basketCheckout.BasketId);
                return Accepted(basketCheckoutMessage);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.StackTrace);
            }
        }

    }
}
