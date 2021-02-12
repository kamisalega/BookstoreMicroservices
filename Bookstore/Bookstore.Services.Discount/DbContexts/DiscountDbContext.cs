using System;
using Bookstore.Services.Discount.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services.Discount.DbContexts
{
    public class DiscountDbContext : DbContext
    {
        public DiscountDbContext(DbContextOptions<DiscountDbContext> options) : base(options)
        {

        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = Guid.NewGuid(),
                Code = "SuperKsiazka",
                Amount = 10,
                AlreadyUsed = false
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = Guid.NewGuid(),
                Code = "Wow",
                Amount = 20,
                AlreadyUsed = false
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = Guid.NewGuid(),
                Code = "WszystkoZaDarmo",
                Amount = 100,
                AlreadyUsed = false
            });
        }
    }
}
