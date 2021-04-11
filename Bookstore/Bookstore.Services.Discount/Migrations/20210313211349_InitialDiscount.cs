using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Services.Discount.Migrations
{
    public partial class InitialDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    CouponId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    AlreadyUsed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.CouponId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
