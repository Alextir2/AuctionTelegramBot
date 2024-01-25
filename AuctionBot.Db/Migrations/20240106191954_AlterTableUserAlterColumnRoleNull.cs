using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionBot.Db.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableUserAlterColumnRoleNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Role",
                table: "Users",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 6, 19, 19, 54, 140, DateTimeKind.Utc).AddTicks(9041), new DateTime(2024, 1, 6, 19, 19, 54, 140, DateTimeKind.Utc).AddTicks(9042) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 6, 19, 19, 54, 140, DateTimeKind.Utc).AddTicks(9044), new DateTime(2024, 1, 6, 19, 19, 54, 140, DateTimeKind.Utc).AddTicks(9044) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 6, 19, 19, 54, 141, DateTimeKind.Utc).AddTicks(1108), new DateTime(2024, 1, 6, 19, 19, 54, 141, DateTimeKind.Utc).AddTicks(1109) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 6, 19, 19, 54, 141, DateTimeKind.Utc).AddTicks(1114), new DateTime(2024, 1, 6, 19, 19, 54, 141, DateTimeKind.Utc).AddTicks(1114) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 6, 19, 19, 54, 140, DateTimeKind.Utc).AddTicks(8194), new DateTime(2024, 1, 6, 19, 19, 54, 140, DateTimeKind.Utc).AddTicks(8192) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 6, 19, 19, 54, 140, DateTimeKind.Utc).AddTicks(8201), new DateTime(2024, 1, 6, 19, 19, 54, 140, DateTimeKind.Utc).AddTicks(8201) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Role",
                table: "Users",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "smallint",
                oldNullable: true);

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
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 6, 19, 15, 39, 389, DateTimeKind.Utc).AddTicks(8205), new DateTime(2024, 1, 6, 19, 15, 39, 389, DateTimeKind.Utc).AddTicks(8203) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 6, 19, 15, 39, 389, DateTimeKind.Utc).AddTicks(8213), new DateTime(2024, 1, 6, 19, 15, 39, 389, DateTimeKind.Utc).AddTicks(8213) });
        }
    }
}
