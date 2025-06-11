using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBazzar.Migrations
{
    /// <inheritdoc />
    public partial class FinalPaymentMigrationDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payments_discounts_discount_id",
                table: "payments");

            migrationBuilder.DropForeignKey(
                name: "FK_payments_orders_order_id1",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_payments_discount_id",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_payments_order_id1",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "discount_id",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "order_id1",
                table: "payments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "discount_id",
                table: "payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "order_id1",
                table: "payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_payments_discount_id",
                table: "payments",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_order_id1",
                table: "payments",
                column: "order_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_payments_discounts_discount_id",
                table: "payments",
                column: "discount_id",
                principalTable: "discounts",
                principalColumn: "discount_id");

            migrationBuilder.AddForeignKey(
                name: "FK_payments_orders_order_id1",
                table: "payments",
                column: "order_id1",
                principalTable: "orders",
                principalColumn: "order_id");
        }
    }
}
