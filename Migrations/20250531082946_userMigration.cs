using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBazzar.Migrations
{
    /// <inheritdoc />
    public partial class userMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "wishlist_id",
                table: "cartItems");

            migrationBuilder.AddColumn<string>(
                name: "UserImage",
                table: "users",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserisActive",
                table: "users",
                type: "varchar(10)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserImage",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserisActive",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "wishlist_id",
                table: "cartItems",
                type: "int",
                nullable: true);
        }
    }
}
