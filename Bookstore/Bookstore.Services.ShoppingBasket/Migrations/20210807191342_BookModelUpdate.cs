using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Services.ShoppingBasket.Migrations
{
    public partial class BookModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("01457142-358f-495f-aafa-fb23de3d67e9"),
                column: "Date",
                value: new DateTime(2022, 5, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("09af5a52-9421-44e8-a2bb-a6b9ccbc8239"),
                column: "Date",
                value: new DateTime(2022, 3, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("1325360c-8253-473a-a20f-55c269c20407"),
                column: "Date",
                value: new DateTime(2022, 7, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9736));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("447eb762-95e9-4c31-95e1-b20053fbe215"),
                column: "Date",
                value: new DateTime(2022, 1, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("60188a2b-2784-4fc4-8df8-8919ff838b0b"),
                column: "Date",
                value: new DateTime(2021, 12, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9709));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("70a1f9b9-0a37-4c1a-99b1-c7709fc64167"),
                column: "Date",
                value: new DateTime(2021, 11, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9670));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("9edf91ee-ab77-4521-a402-5f188bc0c577"),
                column: "Date",
                value: new DateTime(2022, 4, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
                column: "Date",
                value: new DateTime(2021, 10, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9641));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("bc4c35c3-3857-4250-9449-155fcf5109ec"),
                column: "Date",
                value: new DateTime(2022, 2, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                column: "Date",
                value: new DateTime(2021, 9, 3, 18, 10, 9, 586, DateTimeKind.Local).AddTicks(8333));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("e57b605f-8b3c-4089-b672-6ce9e6d6c23f"),
                column: "Date",
                value: new DateTime(2022, 6, 3, 18, 10, 9, 587, DateTimeKind.Local).AddTicks(9732));
        }
    }
}
