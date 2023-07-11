using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeekShooping.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 2L, "T-Shirt 2", "Description T-Shirt 2", "https://raw.githubusercontent.com/leleomaster/leo-microservices-dotnet6/master/ShoppingImages/11_mars.jpg", "Name 2", 62.9m },
                    { 3L, "T-Shirt 3", "Description T-Shirt 3", "https://raw.githubusercontent.com/leleomaster/leo-microservices-dotnet6/master/ShoppingImages/11_mars.jpg", "Name 3", 63.9m },
                    { 4L, "T-Shirt 4", "Description T-Shirt 4", "https://raw.githubusercontent.com/leleomaster/leo-microservices-dotnet6/master/ShoppingImages/11_mars.jpg", "Name 4", 64.9m },
                    { 5L, "T-Shirt 5", "Description T-Shirt 5", "https://raw.githubusercontent.com/leleomaster/leo-microservices-dotnet6/master/ShoppingImages/11_mars.jpg", "Name 5", 65.9m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 5L);
        }
    }
}
