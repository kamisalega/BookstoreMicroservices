using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Services.ShoppingBasket.Migrations
{
    public partial class BookAuthorv2Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateOfDeath = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("01457142-358f-495f-aafa-fb23de3d67e9"),
                column: "Date",
                value: new DateTime(2022, 5, 10, 18, 48, 23, 124, DateTimeKind.Local).AddTicks(9130));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("09af5a52-9421-44e8-a2bb-a6b9ccbc8239"),
                column: "Date",
                value: new DateTime(2022, 3, 10, 18, 48, 23, 124, DateTimeKind.Local).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("1325360c-8253-473a-a20f-55c269c20407"),
                column: "Date",
                value: new DateTime(2022, 7, 10, 18, 48, 23, 124, DateTimeKind.Local).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("447eb762-95e9-4c31-95e1-b20053fbe215"),
                column: "Date",
                value: new DateTime(2022, 1, 10, 18, 48, 23, 124, DateTimeKind.Local).AddTicks(9115));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("60188a2b-2784-4fc4-8df8-8919ff838b0b"),
                column: "Date",
                value: new DateTime(2021, 12, 10, 18, 48, 23, 124, DateTimeKind.Local).AddTicks(9110));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("70a1f9b9-0a37-4c1a-99b1-c7709fc64167"),
                column: "Date",
                value: new DateTime(2021, 11, 10, 18, 48, 23, 124, DateTimeKind.Local).AddTicks(9104));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("9edf91ee-ab77-4521-a402-5f188bc0c577"),
                column: "Date",
                value: new DateTime(2022, 4, 10, 18, 48, 23, 124, DateTimeKind.Local).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
                column: "Date",
                value: new DateTime(2021, 10, 10, 18, 48, 23, 124, DateTimeKind.Local).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("bc4c35c3-3857-4250-9449-155fcf5109ec"),
                column: "Date",
                value: new DateTime(2022, 2, 10, 18, 48, 23, 124, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                column: "Date",
                value: new DateTime(2021, 9, 10, 18, 48, 23, 123, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("e57b605f-8b3c-4089-b672-6ce9e6d6c23f"),
                column: "Date",
                value: new DateTime(2022, 6, 10, 18, 48, 23, 124, DateTimeKind.Local).AddTicks(9134));

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("01457142-358f-495f-aafa-fb23de3d67e9"),
                column: "Date",
                value: new DateTime(2022, 5, 10, 18, 4, 26, 195, DateTimeKind.Local).AddTicks(2886));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("09af5a52-9421-44e8-a2bb-a6b9ccbc8239"),
                column: "Date",
                value: new DateTime(2022, 3, 10, 18, 4, 26, 195, DateTimeKind.Local).AddTicks(2876));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("1325360c-8253-473a-a20f-55c269c20407"),
                column: "Date",
                value: new DateTime(2022, 7, 10, 18, 4, 26, 195, DateTimeKind.Local).AddTicks(2897));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("447eb762-95e9-4c31-95e1-b20053fbe215"),
                column: "Date",
                value: new DateTime(2022, 1, 10, 18, 4, 26, 195, DateTimeKind.Local).AddTicks(2869));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("60188a2b-2784-4fc4-8df8-8919ff838b0b"),
                column: "Date",
                value: new DateTime(2021, 12, 10, 18, 4, 26, 195, DateTimeKind.Local).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("70a1f9b9-0a37-4c1a-99b1-c7709fc64167"),
                column: "Date",
                value: new DateTime(2021, 11, 10, 18, 4, 26, 195, DateTimeKind.Local).AddTicks(2859));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("9edf91ee-ab77-4521-a402-5f188bc0c577"),
                column: "Date",
                value: new DateTime(2022, 4, 10, 18, 4, 26, 195, DateTimeKind.Local).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
                column: "Date",
                value: new DateTime(2021, 10, 10, 18, 4, 26, 195, DateTimeKind.Local).AddTicks(2824));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("bc4c35c3-3857-4250-9449-155fcf5109ec"),
                column: "Date",
                value: new DateTime(2022, 2, 10, 18, 4, 26, 195, DateTimeKind.Local).AddTicks(2872));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                column: "Date",
                value: new DateTime(2021, 9, 10, 18, 4, 26, 194, DateTimeKind.Local).AddTicks(655));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("e57b605f-8b3c-4089-b672-6ce9e6d6c23f"),
                column: "Date",
                value: new DateTime(2022, 6, 10, 18, 4, 26, 195, DateTimeKind.Local).AddTicks(2891));
        }
    }
}
