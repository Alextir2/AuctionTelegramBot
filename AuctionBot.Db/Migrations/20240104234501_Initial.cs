using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AuctionBot.Db.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TelegramUserChatId = table.Column<long>(type: "bigint", nullable: false),
                    Role = table.Column<byte>(type: "smallint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    Path = table.Column<string>(type: "varchar", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDt", "IsDeleted", "Name", "UpdateDt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 4, 23, 45, 1, 208, DateTimeKind.Utc).AddTicks(203), false, "Овощи", new DateTime(2024, 1, 4, 23, 45, 1, 208, DateTimeKind.Utc).AddTicks(204) },
                    { 2, new DateTime(2024, 1, 4, 23, 45, 1, 208, DateTimeKind.Utc).AddTicks(207), false, "Фрукты", new DateTime(2024, 1, 4, 23, 45, 1, 208, DateTimeKind.Utc).AddTicks(208) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDt", "IsDeleted", "Role", "TelegramUserChatId", "UpdateDt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 4, 23, 45, 1, 207, DateTimeKind.Utc).AddTicks(9419), false, (byte)2, 1L, new DateTime(2024, 1, 4, 23, 45, 1, 207, DateTimeKind.Utc).AddTicks(9416) },
                    { 2, new DateTime(2024, 1, 4, 23, 45, 1, 207, DateTimeKind.Utc).AddTicks(9423), false, (byte)1, 2L, new DateTime(2024, 1, 4, 23, 45, 1, 207, DateTimeKind.Utc).AddTicks(9422) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreateDt", "IsDeleted", "Name", "Price", "UpdateDt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 4, 23, 45, 1, 208, DateTimeKind.Utc).AddTicks(2340), false, "Огурцы", 12m, new DateTime(2024, 1, 4, 23, 45, 1, 208, DateTimeKind.Utc).AddTicks(2341), 1 },
                    { 2, 2, new DateTime(2024, 1, 4, 23, 45, 1, 208, DateTimeKind.Utc).AddTicks(2348), false, "Абрикосы", 10m, new DateTime(2024, 1, 4, 23, 45, 1, 208, DateTimeKind.Utc).AddTicks(2348), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
