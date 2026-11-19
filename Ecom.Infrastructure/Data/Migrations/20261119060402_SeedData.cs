using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecom.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Electronic devices and gadgets", "Electronics" },
                    { 2, "Apparel and fashion items", "Clothing" },
                    { 3, "Books and literature", "Books" },
                    { 4, "Household and kitchen items", "Home & Kitchen" },
                    { 5, "Sports equipment and outdoor gear", "Sports & Outdoors" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Latest smartphone with advanced features", "Smartphone", 699.99m },
                    { 2, 1, "High-performance laptop for work and gaming", "Laptop", 1299.99m },
                    { 3, 2, "Comfortable cotton t-shirt in various sizes", "T-Shirt", 19.99m },
                    { 4, 2, "Stylish denim jeans for casual wear", "Jeans", 49.99m },
                    { 5, 3, "Bestselling fiction novel by a renowned author", "Novel", 14.99m },
                    { 6, 3, "Collection of delicious recipes for home cooking", "Cookbook", 24.99m },
                    { 7, 4, "Powerful blender for smoothies and food preparation", "Blender", 89.99m },
                    { 8, 4, "Efficient vacuum cleaner for home cleaning", "Vacuum Cleaner", 149.99m },
                    { 9, 5, "Non-slip yoga mat for exercise and meditation", "Yoga Mat", 29.99m },
                    { 10, 5, "Durable camping tent for outdoor adventures", "Tent", 199.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
