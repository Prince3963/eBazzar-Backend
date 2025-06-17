using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBazzar.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_addresse_address_id",
                table: "orderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_products_product_id",
                table: "orderDetails");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_address_id",
                table: "orderDetails");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_product_id",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "addressId",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "address_id",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "invoiceId",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "orderDetails");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_productId",
                table: "orderDetails",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_products_productId",
                table: "orderDetails",
                column: "productId",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_products_productId",
                table: "orderDetails");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_productId",
                table: "orderDetails");

            migrationBuilder.AddColumn<int>(
                name: "addressId",
                table: "orderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "address_id",
                table: "orderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "invoiceId",
                table: "orderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "orderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_address_id",
                table: "orderDetails",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_product_id",
                table: "orderDetails",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_addresse_address_id",
                table: "orderDetails",
                column: "address_id",
                principalTable: "addresse",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_products_product_id",
                table: "orderDetails",
                column: "product_id",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
