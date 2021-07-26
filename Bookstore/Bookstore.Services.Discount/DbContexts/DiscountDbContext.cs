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
                CouponId = Guid.Parse("{9E2D037C-D46A-4D02-910D-3E06791CDA1D}"),
                UserId = Guid.Parse("{E455A3DF-7FA5-47E0-8435-179B300D531F}"),
                Code = "SuperKsiazka",
                Amount = 10,
                AlreadyUsed = false
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = Guid.Parse("{91378F11-6F7A-4F8B-AC1D-FA288F6E2673}"),
                UserId = Guid.Parse("{bbf594b0-3761-4a65-b04c-eec4836d9070}"),
                Code = "Wow",
                Amount = 20,
                AlreadyUsed = false
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = Guid.Parse("{20C5A056-B4BE-4DB9-BB4C-FB7DC97DFFC4}"),
                UserId = Guid.Parse("{3ebca9a3-1b10-469b-a3db-46bdda9d42a4}"),
                Code = "WszystkoZaDarmo",
                Amount = 100,
                AlreadyUsed = false
            });
        }
    }
}
