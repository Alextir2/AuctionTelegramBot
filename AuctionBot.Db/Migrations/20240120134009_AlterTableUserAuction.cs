using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionBot.Db.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableUserAuction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Auctions");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 20, 13, 40, 9, 822, DateTimeKind.Utc).AddTicks(6732), new DateTime(2024, 1, 20, 13, 40, 9, 822, DateTimeKind.Utc).AddTicks(6733) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 20, 13, 40, 9, 822, DateTimeKind.Utc).AddTicks(6735), new DateTime(2024, 1, 20, 13, 40, 9, 822, DateTimeKind.Utc).AddTicks(6735) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 20, 13, 40, 9, 822, DateTimeKind.Utc).AddTicks(8969), new DateTime(2024, 1, 20, 13, 40, 9, 822, DateTimeKind.Utc).AddTicks(8970) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 20, 13, 40, 9, 822, DateTimeKind.Utc).AddTicks(8977), new DateTime(2024, 1, 20, 13, 40, 9, 822, DateTimeKind.Utc).AddTicks(8977) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 20, 13, 40, 9, 822, DateTimeKind.Utc).AddTicks(5841), new DateTime(2024, 1, 20, 13, 40, 9, 822, DateTimeKind.Utc).AddTicks(5837) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 20, 13, 40, 9, 822, DateTimeKind.Utc).AddTicks(5845), new DateTime(2024, 1, 20, 13, 40, 9, 822, DateTimeKind.Utc).AddTicks(5844) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "Auctions",
                type: "integer",
                nullable: true);

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
        }
    }
}
