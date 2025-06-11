using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBazzar.Migrations
{
    /// <inheritdoc />
    public partial class FinalPaymentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payments_discounts_discount_id1",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_payments_discount_id1",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "discount_id1",
                table: "payments");

            migrationBuilder.CreateIndex(
                name: "IX_payments_discount_id",
                table: "payments",
                column: "discount_id");

            migrationBuilder.AddForeignKey(
                name: "FK_payments_discounts_discount_id",
                table: "payments",
                column: "discount_id",
                principalTable: "discounts",
                principalColumn: "discount_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payments_discounts_discount_id",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_payments_discount_id",
                table: "payments");

            migrationBuilder.AddColumn<int>(
                name: "discount_id1",
                table: "payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_payments_discount_id1",
                table: "payments",
                column: "discount_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_payments_discounts_discount_id1",
                table: "payments",
                column: "discount_id1",
                principalTable: "discounts",
                principalColumn: "discount_id");
        }
    }
}
