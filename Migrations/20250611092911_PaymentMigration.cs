using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBazzar.Migrations
{
    /// <inheritdoc />
    public partial class PaymentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payments_users_user_id1",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_payments_user_id1",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "PaymentTransactionId",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "RazorpayPaymentId",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "RazorpaySignature",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "user_id1",
                table: "payments");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "payments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "razorpayOrderId",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_payments_user_id",
                table: "payments",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_payments_users_user_id",
                table: "payments",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payments_users_user_id",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_payments_user_id",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "razorpayOrderId",
                table: "orders");

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "payments",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "payments",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTransactionId",
                table: "payments",
                type: "varchar(255)",
                nullable: true);

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

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "user_id1",
                table: "payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_payments_user_id1",
                table: "payments",
                column: "user_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_payments_users_user_id1",
                table: "payments",
                column: "user_id1",
                principalTable: "users",
                principalColumn: "user_id");
        }
    }
}
