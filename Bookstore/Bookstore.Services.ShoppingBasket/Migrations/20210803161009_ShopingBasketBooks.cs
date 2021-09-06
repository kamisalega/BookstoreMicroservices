using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Services.ShoppingBasket.Migrations
{
    public partial class ShopingBasketBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Date", "Title" },
                values: new object[,]
                {
                    { new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"), new DateTime(2021, 9, 3, 18, 10, 9, 586, DateTimeKind.Local).AddTicks(8333), "The Shining" },
                    { new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"), new DateTime(2021, 10, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9641), "Misery" },
                    { new Guid("70a1f9b9-0a37-4c1a-99b1-c7709fc64167"), new DateTime(2021, 11, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9670), "It" },
                    { new Guid("60188a2b-2784-4fc4-8df8-8919ff838b0b"), new DateTime(2021, 12, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9709), "The Stand" },
                    { new Guid("447eb762-95e9-4c31-95e1-b20053fbe215"), new DateTime(2022, 1, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9713), "A Game of Thrones" },
                    { new Guid("bc4c35c3-3857-4250-9449-155fcf5109ec"), new DateTime(2022, 2, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9717), "The Winds of Winter" },
                    { new Guid("09af5a52-9421-44e8-a2bb-a6b9ccbc8239"), new DateTime(2022, 3, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9721), "A Dance with Dragons" },
                    { new Guid("9edf91ee-ab77-4521-a402-5f188bc0c577"), new DateTime(2022, 4, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9725), "American Gods" },
                    { new Guid("01457142-358f-495f-aafa-fb23de3d67e9"), new DateTime(2022, 5, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9728), "Speechless" },
                    { new Guid("e57b605f-8b3c-4089-b672-6ce9e6d6c23f"), new DateTime(2022, 6, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9732), "The Hitchhiker's Guide to the Galaxy" },
                    { new Guid("1325360c-8253-473a-a20f-55c269c20407"), new DateTime(2022, 7, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9736), "Easy Money" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("01457142-358f-495f-aafa-fb23de3d67e9"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("09af5a52-9421-44e8-a2bb-a6b9ccbc8239"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("1325360c-8253-473a-a20f-55c269c20407"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("447eb762-95e9-4c31-95e1-b20053fbe215"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("60188a2b-2784-4fc4-8df8-8919ff838b0b"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("70a1f9b9-0a37-4c1a-99b1-c7709fc64167"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("9edf91ee-ab77-4521-a402-5f188bc0c577"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("bc4c35c3-3857-4250-9449-155fcf5109ec"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("e57b605f-8b3c-4089-b672-6ce9e6d6c23f"));
        }
    }
}
