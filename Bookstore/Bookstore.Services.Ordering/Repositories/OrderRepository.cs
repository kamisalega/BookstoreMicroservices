using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Services.Ordering.DbContexts;
using Bookstore.Services.Ordering.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services.Ordering.Repositories
{
    public class OrderRepository  : IOrderRepository
    {
        private readonly DbContextOptions<OrderDbContext> dbContextOptions;

        public OrderRepository(DbContextOptions<OrderDbContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public async Task<List<Order>> GetOrdersForUser(Guid userId)
        {
            await using var orderDbContext = new OrderDbContext(dbContextOptions);
            return await orderDbContext.Orders.Where(o => o.UserId == userId).OrderBy(o => o.OrderPlaced).ToListAsync();
        }

        public async Task AddOrder(Order order)
        {
            await using (var orderDbContext = new OrderDbContext(dbContextOptions))
            {
                await orderDbContext.Orders.AddAsync(order);
                await orderDbContext.SaveChangesAsync();
            }
        }

        public async Task<Order> GetOrderById(Guid orderId)
        {
            using (var orderDbContext = new OrderDbContext(dbContextOptions))
            {
                return await orderDbContext.Orders.Where(o => o.Id == orderId).FirstOrDefaultAsync();
            }
        }

        public async Task UpdateOrderPaymentStatus(Guid orderId, bool paid)
        {
            await using (var orderDbContext = new OrderDbContext(dbContextOptions))
            {
                var order = await orderDbContext.Orders.Where(o => o.Id == orderId).FirstOrDefaultAsync();
                order.OrderPaid = paid;
                await orderDbContext.SaveChangesAsync();
            }
        }
    }
}
