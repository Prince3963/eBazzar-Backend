﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBazzar.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresse",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "varchar(50)", nullable: true),
                    Street = table.Column<string>(type: "varchar(255)", nullable: true),
                    City = table.Column<string>(type: "varchar(255)", nullable: true),
                    State = table.Column<string>(type: "varchar(255)", nullable: true),
                    Zipcode = table.Column<string>(type: "varchar(50)", nullable: true),
                    Landmark = table.Column<string>(type: "varchar(255)", nullable: true),
                    Country = table.Column<string>(type: "varchar(255)", nullable: true),
                    isDefault = table.Column<string>(type: "varchar(255)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresse", x => x.address_id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(50)", nullable: true),
                    CategoryDescription = table.Column<string>(type: "varchar(500)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "varchar(50)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "varchar(255)", nullable: true),
                    ProductDescription = table.Column<string>(type: "varchar(255)", nullable: true),
                    ProductPrice = table.Column<int>(type: "int", nullable: true),
                    ProductImage = table.Column<string>(type: "varchar(255)", nullable: true),
                    ProductisActive = table.Column<string>(type: "varchar(10)", nullable: true),
                    ProductSlug = table.Column<string>(type: "varchar(255)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id");
                });

            migrationBuilder.CreateTable(
                name: "cartItems",
                columns: table => new
                {
                    cartItmeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    addedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartItems", x => x.cartItmeId);
                    table.ForeignKey(
                        name: "FK_cartItems_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", nullable: true),
                    UserEmail = table.Column<string>(type: "varchar(255)", nullable: true),
                    UserMobile = table.Column<string>(type: "varchar(12)", nullable: true),
                    UserPassword = table.Column<string>(type: "varchar(250)", nullable: true),
                    forgotPasswordToken = table.Column<string>(type: "varchar(255)", nullable: true),
                    tokanExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserisActive = table.Column<string>(type: "varchar(10)", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_users_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<string>(type: "varchar(10)", nullable: true),
                    OrderStatus = table.Column<string>(type: "varchar(15)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    user_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_orders_users_user_id1",
                        column: x => x.user_id1,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    review_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewRate = table.Column<string>(type: "varchar(255)", nullable: true),
                    ReviewText = table.Column<string>(type: "varchar(255)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    product_id1 = table.Column<int>(type: "int", nullable: true),
                    user_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_reviews_products_product_id1",
                        column: x => x.product_id1,
                        principalTable: "products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK_reviews_users_user_id1",
                        column: x => x.user_id1,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "wishlists",
                columns: table => new
                {
                    wishlist_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    user_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wishlists", x => x.wishlist_id);
                    table.ForeignKey(
                        name: "FK_wishlists_users_user_id1",
                        column: x => x.user_id1,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "orderDetails",
                columns: table => new
                {
                    orderDetaails_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderQuantity = table.Column<int>(type: "int", nullable: true),
                    OrderFinalPrice = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    order_id = table.Column<int>(type: "int", nullable: true),
                    order_id1 = table.Column<int>(type: "int", nullable: true),
                    product_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetails", x => x.orderDetaails_id);
                    table.ForeignKey(
                        name: "FK_orderDetails_orders_order_id1",
                        column: x => x.order_id1,
                        principalTable: "orders",
                        principalColumn: "order_id");
                    table.ForeignKey(
                        name: "FK_orderDetails_products_product_id1",
                        column: x => x.product_id1,
                        principalTable: "products",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "discounts",
                columns: table => new
                {
                    discount_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalValue = table.Column<int>(type: "int", nullable: true),
                    DiscountValidation = table.Column<string>(type: "varchar(30)", nullable: true),
                    DiscountIamge = table.Column<string>(type: "varchar(255)", nullable: true),
                    DiscountType = table.Column<string>(type: "varchar(15)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    wishlist_id = table.Column<int>(type: "int", nullable: true),
                    wishlist_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discounts", x => x.discount_id);
                    table.ForeignKey(
                        name: "FK_discounts_wishlists_wishlist_id1",
                        column: x => x.wishlist_id1,
                        principalTable: "wishlists",
                        principalColumn: "wishlist_id");
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    payment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethods = table.Column<string>(type: "varchar(255)", nullable: true),
                    PaymentTransaction = table.Column<string>(type: "varchar(255)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentStatus = table.Column<string>(type: "varchar(10)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    order_id = table.Column<int>(type: "int", nullable: true),
                    discount_id = table.Column<int>(type: "int", nullable: true),
                    discount_id1 = table.Column<int>(type: "int", nullable: true),
                    user_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_payments_discounts_discount_id1",
                        column: x => x.discount_id1,
                        principalTable: "discounts",
                        principalColumn: "discount_id");
                    table.ForeignKey(
                        name: "FK_payments_users_user_id1",
                        column: x => x.user_id1,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartItems_product_id",
                table: "cartItems",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_discounts_wishlist_id1",
                table: "discounts",
                column: "wishlist_id1");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_order_id1",
                table: "orderDetails",
                column: "order_id1");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_product_id1",
                table: "orderDetails",
                column: "product_id1");

            migrationBuilder.CreateIndex(
                name: "IX_orders_user_id1",
                table: "orders",
                column: "user_id1");

            migrationBuilder.CreateIndex(
                name: "IX_payments_discount_id1",
                table: "payments",
                column: "discount_id1");

            migrationBuilder.CreateIndex(
                name: "IX_payments_user_id1",
                table: "payments",
                column: "user_id1");

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_product_id1",
                table: "reviews",
                column: "product_id1");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_user_id1",
                table: "reviews",
                column: "user_id1");

            migrationBuilder.CreateIndex(
                name: "IX_users_product_id",
                table: "users",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_wishlists_user_id1",
                table: "wishlists",
                column: "user_id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresse");

            migrationBuilder.DropTable(
                name: "cartItems");

            migrationBuilder.DropTable(
                name: "orderDetails");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "discounts");

            migrationBuilder.DropTable(
                name: "wishlists");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
