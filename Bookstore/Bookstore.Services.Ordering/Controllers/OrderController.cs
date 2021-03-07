using System;
using System.Threading.Tasks;
using Bookstore.Services.Ordering.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Services.Ordering.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> List(Guid userId)
        {
            var orders = await _orderRepository.GetOrdersForUser(userId);
            return Ok(orders);
        }
    }
}
