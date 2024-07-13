using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eccommerce.Infrastructure.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Devices", "Electronics" },
                    { 2, "Books,and novels", "Books" },
                    { 3, "apparel and accessories", "Clothing" },
                    { 4, "apparel and accessories", "Home" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Phone", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "sabrahanien@gmail.com", "12345678", "0597088628", "user", "Haneen" },
                    { 2, "sabrahanien2@gmail.com", "1234567", "0597088629", "Admin", "Haneen2" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "OrderStatus", "UsersId", "amount" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 13, 1, 6, 8, 301, DateTimeKind.Local).AddTicks(6046), "pending", 1, 19 },
                    { 2, new DateTime(2024, 7, 13, 1, 6, 8, 301, DateTimeKind.Local).AddTicks(6086), "pending", 2, 19 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoriesId", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, null, "smartphone", 400 },
                    { 2, 1, null, "laptops", 2500 },
                    { 3, 3, null, "short", 100 },
                    { 4, 1, null, "smartphone", 400 },
                    { 5, 2, null, "davince code", 400 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetailes",
                columns: new[] { "OrdersId", "ProductsId", "Id", "Price", "Quantity" },
                values: new object[] { 1, 1, 1, 345, 3 });

            migrationBuilder.InsertData(
                table: "OrderDetailes",
                columns: new[] { "OrdersId", "ProductsId", "Id", "Price", "Quantity" },
                values: new object[] { 2, 3, 2, 245, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderDetailes",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderDetailes",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
