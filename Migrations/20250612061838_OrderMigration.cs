using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBazzar.Migrations
{
    /// <inheritdoc />
    public partial class OrderMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order_id",
                table: "payments");

            migrationBuilder.RenameColumn(
                name: "razorpayOrderId",
                table: "orders",
                newName: "razorpay_order_id");

            migrationBuilder.AddColumn<string>(
                name: "Extra",
                table: "orders",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Paymentspayment_id",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "address_id",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "address_id1",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_address_id1",
                table: "orders",
                column: "address_id1");

            migrationBuilder.CreateIndex(
                name: "IX_orders_Paymentspayment_id",
                table: "orders",
                column: "Paymentspayment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_addresse_address_id1",
                table: "orders",
                column: "address_id1",
                principalTable: "addresse",
                principalColumn: "address_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_payments_Paymentspayment_id",
                table: "orders",
                column: "Paymentspayment_id",
                principalTable: "payments",
                principalColumn: "payment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_addresse_address_id1",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_payments_Paymentspayment_id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_address_id1",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_Paymentspayment_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Extra",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Paymentspayment_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "address_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "address_id1",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "razorpay_order_id",
                table: "orders",
                newName: "razorpayOrderId");

            migrationBuilder.AddColumn<int>(
                name: "order_id",
                table: "payments",
                type: "int",
                nullable: true);
        }
    }
}
