using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Services.ShoppingBasket.Migrations
{
    public partial class ShoppingBasketV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 568, DateTimeKind.Local).AddTicks(6595)),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(679))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasketChangeBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsertedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    BasketChangeType = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(2447)),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(2764))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketChangeBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    BasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CouponId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(1653)),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(2082))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.BasketId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(4878)),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(5413))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketLines",
                columns: table => new
                {
                    BasketLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookAmount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(3263)),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(4283))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketLines", x => x.BasketLineId);
                    table.ForeignKey(
                        name: "FK_BasketLines_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "BasketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketLines_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketLines_BasketId",
                table: "BasketLines",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketLines_BookId",
                table: "BasketLines",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketChangeBooks");

            migrationBuilder.DropTable(
                name: "BasketLines");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
