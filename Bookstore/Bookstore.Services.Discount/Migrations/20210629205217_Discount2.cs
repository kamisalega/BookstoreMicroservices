using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Services.Discount.Migrations
{
    public partial class Discount2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: new Guid("20c5a056-b4be-4db9-bb4c-fb7dc97dffc4"),
                columns: new[] { "Amount", "Code", "UserId" },
                values: new object[] { 100, "WszystkoZaDarmo", new Guid("3ebca9a3-1b10-469b-a3db-46bdda9d42a4") });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: new Guid("91378f11-6f7a-4f8b-ac1d-fa288f6e2673"),
                column: "UserId",
                value: new Guid("bbf594b0-3761-4a65-b04c-eec4836d9070"));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: new Guid("9e2d037c-d46a-4d02-910d-3e06791cda1d"),
                columns: new[] { "Amount", "Code", "UserId" },
                values: new object[] { 10, "SuperKsiazka", new Guid("e455a3df-7fa5-47e0-8435-179b300d531f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: new Guid("20c5a056-b4be-4db9-bb4c-fb7dc97dffc4"),
                columns: new[] { "Amount", "Code", "UserId" },
                values: new object[] { 10, "SuperKsiazka", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: new Guid("91378f11-6f7a-4f8b-ac1d-fa288f6e2673"),
                column: "UserId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: new Guid("9e2d037c-d46a-4d02-910d-3e06791cda1d"),
                columns: new[] { "Amount", "Code", "UserId" },
                values: new object[] { 100, "WszystkoZaDarmo", new Guid("00000000-0000-0000-0000-000000000000") });
        }
    }
}
