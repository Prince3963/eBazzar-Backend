using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBazzar.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_cartItems_product_id",
                table: "cartItems",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_products_product_id",
                table: "cartItems",
                column: "product_id",
                principalTable: "products",
                principalColumn: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_products_product_id",
                table: "cartItems");

            migrationBuilder.DropIndex(
                name: "IX_cartItems_product_id",
                table: "cartItems");
        }
    }
}
