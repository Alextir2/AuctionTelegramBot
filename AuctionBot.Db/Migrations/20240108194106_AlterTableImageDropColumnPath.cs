using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionBot.Db.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableImageDropColumnPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Images");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Images",
                type: "varchar",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 8, 17, 25, 34, 702, DateTimeKind.Utc).AddTicks(457), new DateTime(2024, 1, 8, 17, 25, 34, 702, DateTimeKind.Utc).AddTicks(458) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 8, 17, 25, 34, 702, DateTimeKind.Utc).AddTicks(460), new DateTime(2024, 1, 8, 17, 25, 34, 702, DateTimeKind.Utc).AddTicks(460) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 8, 17, 25, 34, 702, DateTimeKind.Utc).AddTicks(2549), new DateTime(2024, 1, 8, 17, 25, 34, 702, DateTimeKind.Utc).AddTicks(2550) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 8, 17, 25, 34, 702, DateTimeKind.Utc).AddTicks(2557), new DateTime(2024, 1, 8, 17, 25, 34, 702, DateTimeKind.Utc).AddTicks(2557) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 8, 17, 25, 34, 701, DateTimeKind.Utc).AddTicks(9625), new DateTime(2024, 1, 8, 17, 25, 34, 701, DateTimeKind.Utc).AddTicks(9623) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 8, 17, 25, 34, 701, DateTimeKind.Utc).AddTicks(9629), new DateTime(2024, 1, 8, 17, 25, 34, 701, DateTimeKind.Utc).AddTicks(9629) });
        }
    }
}
