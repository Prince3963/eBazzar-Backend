using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBazzar.Migrations
{
    /// <inheritdoc />
    public partial class orderDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "razorpay_order_id",
                table: "orderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_order_id",
                table: "orderDetails",
                column: "order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_orders_order_id",
                table: "orderDetails",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_orders_order_id",
                table: "orderDetails");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_order_id",
                table: "orderDetails");

            migrationBuilder.AlterColumn<string>(
                name: "razorpay_order_id",
                table: "orderDetails",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
