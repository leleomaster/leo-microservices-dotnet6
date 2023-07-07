using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShooping.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddProductDataTableOnDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
