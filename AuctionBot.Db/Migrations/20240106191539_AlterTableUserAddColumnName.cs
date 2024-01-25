using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionBot.Db.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableUserAddColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 6, 19, 15, 39, 389, DateTimeKind.Utc).AddTicks(9056), new DateTime(2024, 1, 6, 19, 15, 39, 389, DateTimeKind.Utc).AddTicks(9057) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 6, 19, 15, 39, 389, DateTimeKind.Utc).AddTicks(9059), new DateTime(2024, 1, 6, 19, 15, 39, 389, DateTimeKind.Utc).AddTicks(9059) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 6, 19, 15, 39, 390, DateTimeKind.Utc).AddTicks(1232), new DateTime(2024, 1, 6, 19, 15, 39, 390, DateTimeKind.Utc).AddTicks(1233) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 6, 19, 15, 39, 390, DateTimeKind.Utc).AddTicks(1238), new DateTime(2024, 1, 6, 19, 15, 39, 390, DateTimeKind.Utc).AddTicks(1239) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "Name", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 6, 19, 15, 39, 389, DateTimeKind.Utc).AddTicks(8205), "@edgerun", new DateTime(2024, 1, 6, 19, 15, 39, 389, DateTimeKind.Utc).AddTicks(8203) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "Name", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 6, 19, 15, 39, 389, DateTimeKind.Utc).AddTicks(8213), "@alextir2", new DateTime(2024, 1, 6, 19, 15, 39, 389, DateTimeKind.Utc).AddTicks(8213) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 4, 23, 45, 1, 208, DateTimeKind.Utc).AddTicks(203), new DateTime(2024, 1, 4, 23, 45, 1, 208, DateTimeKind.Utc).AddTicks(204) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 4, 23, 45, 1, 208, DateTimeKind.Utc).AddTicks(207), new DateTime(2024, 1, 4, 23, 45, 1, 208, DateTimeKind.Utc).AddTicks(208) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 4, 23, 45, 1, 208, DateTimeKind.Utc).AddTicks(2340), new DateTime(2024, 1, 4, 23, 45, 1, 208, DateTimeKind.Utc).AddTicks(2341) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 4, 23, 45, 1, 208, DateTimeKind.Utc).AddTicks(2348), new DateTime(2024, 1, 4, 23, 45, 1, 208, DateTimeKind.Utc).AddTicks(2348) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 4, 23, 45, 1, 207, DateTimeKind.Utc).AddTicks(9419), new DateTime(2024, 1, 4, 23, 45, 1, 207, DateTimeKind.Utc).AddTicks(9416) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 4, 23, 45, 1, 207, DateTimeKind.Utc).AddTicks(9423), new DateTime(2024, 1, 4, 23, 45, 1, 207, DateTimeKind.Utc).AddTicks(9422) });
        }
    }
}
