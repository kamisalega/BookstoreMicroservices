using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Services.ShoppingBasket.Migrations
{
    public partial class  ShoppingBasketV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(8931),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(5413));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(8344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(4878));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(5480),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(2082));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(4980),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(1653));

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "BasketLines",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "BasketLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(7726),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(4283));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "BasketLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(6688),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(3263));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "BasketChangeBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(6167),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(2764));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "BasketChangeBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(5837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(2447));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(4114),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 6, 17, 18, 52, 998, DateTimeKind.Local).AddTicks(9904),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 568, DateTimeKind.Local).AddTicks(6595));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(5413),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(8931));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(4878),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(8344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(2082),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(5480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(1653),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(4980));

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "BasketLines",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "BasketLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(4283),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(7726));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "BasketLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(3263),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(6688));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "BasketChangeBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(2764),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(6167));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "BasketChangeBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(2447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(5837));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 576, DateTimeKind.Local).AddTicks(679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 6, 17, 18, 53, 6, DateTimeKind.Local).AddTicks(4114));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 17, 24, 45, 568, DateTimeKind.Local).AddTicks(6595),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 6, 17, 18, 52, 998, DateTimeKind.Local).AddTicks(9904));
        }
    }
}
