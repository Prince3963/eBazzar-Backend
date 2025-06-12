using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBazzar.Migrations
{
    /// <inheritdoc />
    public partial class TestMigraton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_user_id1",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_user_id1",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "user_id1",
                table: "orders");

            migrationBuilder.CreateTable(
                name: "OrdersUser",
                columns: table => new
                {
                    Usersuser_id = table.Column<int>(type: "int", nullable: false),
                    ordersorder_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersUser", x => new { x.Usersuser_id, x.ordersorder_id });
                    table.ForeignKey(
                        name: "FK_OrdersUser_orders_ordersorder_id",
                        column: x => x.ordersorder_id,
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersUser_users_Usersuser_id",
                        column: x => x.Usersuser_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersUser_ordersorder_id",
                table: "OrdersUser",
                column: "ordersorder_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersUser");

            migrationBuilder.AddColumn<int>(
                name: "user_id1",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_user_id1",
                table: "orders",
                column: "user_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_user_id1",
                table: "orders",
                column: "user_id1",
                principalTable: "users",
                principalColumn: "user_id");
        }
    }
}
