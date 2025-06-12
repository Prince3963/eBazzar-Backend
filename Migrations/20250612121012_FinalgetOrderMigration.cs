using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBazzar.Migrations
{
    /// <inheritdoc />
    public partial class FinalgetOrderMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_product_id",
                table: "orders",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_products_product_id",
                table: "orders",
                column: "product_id",
                principalTable: "products",
                principalColumn: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_products_product_id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_product_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "orders");
        }
    }
}
