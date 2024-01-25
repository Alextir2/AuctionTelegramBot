using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AuctionBot.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableAuction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    SellerId = table.Column<int>(type: "integer", nullable: false),
                    BuyerId = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    EndDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auctions_Users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Auctions_Users_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 13, 12, 47, 56, 67, DateTimeKind.Utc).AddTicks(7669), new DateTime(2024, 1, 13, 12, 47, 56, 67, DateTimeKind.Utc).AddTicks(7669) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 13, 12, 47, 56, 67, DateTimeKind.Utc).AddTicks(7672), new DateTime(2024, 1, 13, 12, 47, 56, 67, DateTimeKind.Utc).AddTicks(7672) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 13, 12, 47, 56, 68, DateTimeKind.Utc).AddTicks(166), new DateTime(2024, 1, 13, 12, 47, 56, 68, DateTimeKind.Utc).AddTicks(166) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 13, 12, 47, 56, 68, DateTimeKind.Utc).AddTicks(173), new DateTime(2024, 1, 13, 12, 47, 56, 68, DateTimeKind.Utc).AddTicks(174) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 13, 12, 47, 56, 67, DateTimeKind.Utc).AddTicks(6752), new DateTime(2024, 1, 13, 12, 47, 56, 67, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 13, 12, 47, 56, 67, DateTimeKind.Utc).AddTicks(6756), new DateTime(2024, 1, 13, 12, 47, 56, 67, DateTimeKind.Utc).AddTicks(6756) });

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_BuyerId",
                table: "Auctions",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_ProductId",
                table: "Auctions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_SellerId",
                table: "Auctions",
                column: "SellerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 8, 19, 41, 6, 851, DateTimeKind.Utc).AddTicks(9524), new DateTime(2024, 1, 8, 19, 41, 6, 851, DateTimeKind.Utc).AddTicks(9524) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 8, 19, 41, 6, 851, DateTimeKind.Utc).AddTicks(9527), new DateTime(2024, 1, 8, 19, 41, 6, 851, DateTimeKind.Utc).AddTicks(9528) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 8, 19, 41, 6, 852, DateTimeKind.Utc).AddTicks(1841), new DateTime(2024, 1, 8, 19, 41, 6, 852, DateTimeKind.Utc).AddTicks(1842) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 8, 19, 41, 6, 852, DateTimeKind.Utc).AddTicks(1847), new DateTime(2024, 1, 8, 19, 41, 6, 852, DateTimeKind.Utc).AddTicks(1848) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 8, 19, 41, 6, 851, DateTimeKind.Utc).AddTicks(8635), new DateTime(2024, 1, 8, 19, 41, 6, 851, DateTimeKind.Utc).AddTicks(8633) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 8, 19, 41, 6, 851, DateTimeKind.Utc).AddTicks(8638), new DateTime(2024, 1, 8, 19, 41, 6, 851, DateTimeKind.Utc).AddTicks(8638) });
        }
    }
}
