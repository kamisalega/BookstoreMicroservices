using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Services.Discount.Migrations
{
    public partial class _202106281322_Discount1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: new Guid("0be058a4-72ad-406e-9e52-40ef9f2f0423"));

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: new Guid("a52b3dde-d046-4e75-bf6c-3368b7fd8204"));

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: new Guid("b71f0000-a7ea-418d-902f-7aa0f4c977c3"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Coupons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "AlreadyUsed", "Amount", "Code", "UserId" },
                values: new object[] { new Guid("20c5a056-b4be-4db9-bb4c-fb7dc97dffc4"), false, 10, "SuperKsiazka", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "AlreadyUsed", "Amount", "Code", "UserId" },
                values: new object[] { new Guid("91378f11-6f7a-4f8b-ac1d-fa288f6e2673"), false, 20, "Wow", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "AlreadyUsed", "Amount", "Code", "UserId" },
                values: new object[] { new Guid("9e2d037c-d46a-4d02-910d-3e06791cda1d"), false, 100, "WszystkoZaDarmo", new Guid("00000000-0000-0000-0000-000000000000") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: new Guid("20c5a056-b4be-4db9-bb4c-fb7dc97dffc4"));

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: new Guid("91378f11-6f7a-4f8b-ac1d-fa288f6e2673"));

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: new Guid("9e2d037c-d46a-4d02-910d-3e06791cda1d"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Coupons");

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "AlreadyUsed", "Amount", "Code" },
                values: new object[] { new Guid("0be058a4-72ad-406e-9e52-40ef9f2f0423"), false, 10, "SuperKsiazka" });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "AlreadyUsed", "Amount", "Code" },
                values: new object[] { new Guid("b71f0000-a7ea-418d-902f-7aa0f4c977c3"), false, 20, "Wow" });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "AlreadyUsed", "Amount", "Code" },
                values: new object[] { new Guid("a52b3dde-d046-4e75-bf6c-3368b7fd8204"), false, 100, "WszystkoZaDarmo" });
        }
    }
}
