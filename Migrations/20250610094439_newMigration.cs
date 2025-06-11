using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBazzar.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentMethods",
                table: "payments",
                newName: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "PaymentTransaction",
                table: "payments",
                newName: "RazorpaySignature");

            migrationBuilder.RenameColumn(
                name: "orderDetaails_id",
                table: "orderDetails",
                newName: "orderDetails_id");

            migrationBuilder.AddColumn<string>(
                name: "PaymentTransactionId",
                table: "payments",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazorpayOrderId",
                table: "payments",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazorpayPaymentId",
                table: "payments",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "order_id1",
                table: "payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_payments_order_id1",
                table: "payments",
                column: "order_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_payments_orders_order_id1",
                table: "payments",
                column: "order_id1",
                principalTable: "orders",
                principalColumn: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payments_orders_order_id1",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_payments_order_id1",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "PaymentTransactionId",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "RazorpayOrderId",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "RazorpayPaymentId",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "order_id1",
                table: "payments");

            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "payments",
                newName: "PaymentMethods");

            migrationBuilder.RenameColumn(
                name: "RazorpaySignature",
                table: "payments",
                newName: "PaymentTransaction");

            migrationBuilder.RenameColumn(
                name: "orderDetails_id",
                table: "orderDetails",
                newName: "orderDetaails_id");
        }
    }
}
