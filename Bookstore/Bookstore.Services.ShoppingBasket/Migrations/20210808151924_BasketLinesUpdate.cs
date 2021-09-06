using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Services.ShoppingBasket.Migrations
{
    public partial class BasketLinesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketAmount",
                table: "BasketLines",
                newName: "BookAmount");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("01457142-358f-495f-aafa-fb23de3d67e9"),
                column: "Date",
                value: new DateTime(2022, 5, 8, 17, 19, 24, 76, DateTimeKind.Local).AddTicks(4304));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("09af5a52-9421-44e8-a2bb-a6b9ccbc8239"),
                column: "Date",
                value: new DateTime(2022, 3, 8, 17, 19, 24, 76, DateTimeKind.Local).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("1325360c-8253-473a-a20f-55c269c20407"),
                column: "Date",
                value: new DateTime(2022, 7, 8, 17, 19, 24, 76, DateTimeKind.Local).AddTicks(4311));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("447eb762-95e9-4c31-95e1-b20053fbe215"),
                column: "Date",
                value: new DateTime(2022, 1, 8, 17, 19, 24, 76, DateTimeKind.Local).AddTicks(4289));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("60188a2b-2784-4fc4-8df8-8919ff838b0b"),
                column: "Date",
                value: new DateTime(2021, 12, 8, 17, 19, 24, 76, DateTimeKind.Local).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("70a1f9b9-0a37-4c1a-99b1-c7709fc64167"),
                column: "Date",
                value: new DateTime(2021, 11, 8, 17, 19, 24, 76, DateTimeKind.Local).AddTicks(4279));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("9edf91ee-ab77-4521-a402-5f188bc0c577"),
                column: "Date",
                value: new DateTime(2022, 4, 8, 17, 19, 24, 76, DateTimeKind.Local).AddTicks(4300));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
                column: "Date",
                value: new DateTime(2021, 10, 8, 17, 19, 24, 76, DateTimeKind.Local).AddTicks(4252));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("bc4c35c3-3857-4250-9449-155fcf5109ec"),
                column: "Date",
                value: new DateTime(2022, 2, 8, 17, 19, 24, 76, DateTimeKind.Local).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                column: "Date",
                value: new DateTime(2021, 9, 8, 17, 19, 24, 75, DateTimeKind.Local).AddTicks(2556));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("e57b605f-8b3c-4089-b672-6ce9e6d6c23f"),
                column: "Date",
                value: new DateTime(2022, 6, 8, 17, 19, 24, 76, DateTimeKind.Local).AddTicks(4308));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookAmount",
                table: "BasketLines",
                newName: "TicketAmount");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("01457142-358f-495f-aafa-fb23de3d67e9"),
                column: "Date",
                value: new DateTime(2022, 5, 7, 21, 13, 41, 868, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("09af5a52-9421-44e8-a2bb-a6b9ccbc8239"),
                column: "Date",
                value: new DateTime(2022, 3, 7, 21, 13, 41, 868, DateTimeKind.Local).AddTicks(6423));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("1325360c-8253-473a-a20f-55c269c20407"),
                column: "Date",
                value: new DateTime(2022, 7, 7, 21, 13, 41, 868, DateTimeKind.Local).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("447eb762-95e9-4c31-95e1-b20053fbe215"),
                column: "Date",
                value: new DateTime(2022, 1, 7, 21, 13, 41, 868, DateTimeKind.Local).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("60188a2b-2784-4fc4-8df8-8919ff838b0b"),
                column: "Date",
                value: new DateTime(2021, 12, 7, 21, 13, 41, 868, DateTimeKind.Local).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("70a1f9b9-0a37-4c1a-99b1-c7709fc64167"),
                column: "Date",
                value: new DateTime(2021, 11, 7, 21, 13, 41, 868, DateTimeKind.Local).AddTicks(6407));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("9edf91ee-ab77-4521-a402-5f188bc0c577"),
                column: "Date",
                value: new DateTime(2022, 4, 7, 21, 13, 41, 868, DateTimeKind.Local).AddTicks(6426));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
                column: "Date",
                value: new DateTime(2021, 10, 7, 21, 13, 41, 868, DateTimeKind.Local).AddTicks(6378));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("bc4c35c3-3857-4250-9449-155fcf5109ec"),
                column: "Date",
                value: new DateTime(2022, 2, 7, 21, 13, 41, 868, DateTimeKind.Local).AddTicks(6419));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                column: "Date",
                value: new DateTime(2021, 9, 7, 21, 13, 41, 867, DateTimeKind.Local).AddTicks(5645));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("e57b605f-8b3c-4089-b672-6ce9e6d6c23f"),
                column: "Date",
                value: new DateTime(2022, 6, 7, 21, 13, 41, 868, DateTimeKind.Local).AddTicks(6433));
        }
    }
}
