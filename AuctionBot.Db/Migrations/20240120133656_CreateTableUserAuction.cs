using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AuctionBot.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableUserAuction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_Users_BuyerId",
                table: "Auctions");

            migrationBuilder.DropIndex(
                name: "IX_Auctions_BuyerId",
                table: "Auctions");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "Auctions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "UserAuctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    AuctionId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAuctions_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAuctions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 20, 13, 36, 56, 519, DateTimeKind.Utc).AddTicks(6703), new DateTime(2024, 1, 20, 13, 36, 56, 519, DateTimeKind.Utc).AddTicks(6704) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 20, 13, 36, 56, 519, DateTimeKind.Utc).AddTicks(6706), new DateTime(2024, 1, 20, 13, 36, 56, 519, DateTimeKind.Utc).AddTicks(6706) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 20, 13, 36, 56, 519, DateTimeKind.Utc).AddTicks(9310), new DateTime(2024, 1, 20, 13, 36, 56, 519, DateTimeKind.Utc).AddTicks(9312) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 20, 13, 36, 56, 519, DateTimeKind.Utc).AddTicks(9319), new DateTime(2024, 1, 20, 13, 36, 56, 519, DateTimeKind.Utc).AddTicks(9319) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 20, 13, 36, 56, 519, DateTimeKind.Utc).AddTicks(5664), new DateTime(2024, 1, 20, 13, 36, 56, 519, DateTimeKind.Utc).AddTicks(5661) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 20, 13, 36, 56, 519, DateTimeKind.Utc).AddTicks(5669), new DateTime(2024, 1, 20, 13, 36, 56, 519, DateTimeKind.Utc).AddTicks(5669) });

            migrationBuilder.CreateIndex(
                name: "IX_UserAuctions_AuctionId",
                table: "UserAuctions",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuctions_UserId",
                table: "UserAuctions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAuctions");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "Auctions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_Users_BuyerId",
                table: "Auctions",
                column: "BuyerId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
