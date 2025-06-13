using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBazzar.Migrations
{
    /// <inheritdoc />
    public partial class CompletedPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_orders_order_id1",
                table: "orderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_products_product_id1",
                table: "orderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_products_product_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_user_id1",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_product_id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_user_id1",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_order_id1",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "OrderFinalPrice",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "order_id1",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "orderDetails");

            migrationBuilder.RenameColumn(
                name: "user_id1",
                table: "orders",
                newName: "payment_id");

            migrationBuilder.RenameColumn(
                name: "OrderQuantity",
                table: "orderDetails",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "product_id1",
                table: "orderDetails",
                newName: "payment_id");

            migrationBuilder.RenameColumn(
                name: "orderDetails_id",
                table: "orderDetails",
                newName: "orderDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_orderDetails_product_id1",
                table: "orderDetails",
                newName: "IX_orderDetails_payment_id");

            migrationBuilder.AddColumn<string>(
                name: "RazorpayPaymentId",
                table: "payments",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazorpaySignature",
                table: "payments",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "orders",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "quantity",
                table: "orderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "orderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "productImage",
                table: "orderDetails",
                type: "varchar(1000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "productName",
                table: "orderDetails",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "productPrice",
                table: "orderDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_orders_user_id",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_productId",
                table: "orderDetails",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_orders_payment_id",
                table: "orderDetails",
                column: "payment_id",
                principalTable: "orders",
                principalColumn: "order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_products_productId",
                table: "orderDetails",
                column: "productId",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_user_id",
                table: "orders",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_orders_payment_id",
                table: "orderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_products_productId",
                table: "orderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_user_id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_user_id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_productId",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "RazorpayPaymentId",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "RazorpaySignature",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "productImage",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "productName",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "productPrice",
                table: "orderDetails");

            migrationBuilder.RenameColumn(
                name: "payment_id",
                table: "orders",
                newName: "user_id1");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "orderDetails",
                newName: "OrderQuantity");

            migrationBuilder.RenameColumn(
                name: "payment_id",
                table: "orderDetails",
                newName: "product_id1");

            migrationBuilder.RenameColumn(
                name: "orderDetailsId",
                table: "orderDetails",
                newName: "orderDetails_id");

            migrationBuilder.RenameIndex(
                name: "IX_orderDetails_payment_id",
                table: "orderDetails",
                newName: "IX_orderDetails_product_id1");

            migrationBuilder.AlterColumn<string>(
                name: "TotalPrice",
                table: "orders",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderQuantity",
                table: "orderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OrderFinalPrice",
                table: "orderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "orderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "order_id1",
                table: "orderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "orderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_product_id",
                table: "orders",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_user_id1",
                table: "orders",
                column: "user_id1");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_order_id1",
                table: "orderDetails",
                column: "order_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_orders_order_id1",
                table: "orderDetails",
                column: "order_id1",
                principalTable: "orders",
                principalColumn: "order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_products_product_id1",
                table: "orderDetails",
                column: "product_id1",
                principalTable: "products",
                principalColumn: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_products_product_id",
                table: "orders",
                column: "product_id",
                principalTable: "products",
                principalColumn: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_user_id1",
                table: "orders",
                column: "user_id1",
                principalTable: "users",
                principalColumn: "user_id");
        }
    }
}
