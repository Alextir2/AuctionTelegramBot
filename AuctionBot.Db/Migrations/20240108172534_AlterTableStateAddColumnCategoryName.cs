using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionBot.Db.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableStateAddColumnCategoryName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "State",
                type: "text",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "State");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 7, 20, 59, 0, 846, DateTimeKind.Utc).AddTicks(867), new DateTime(2024, 1, 7, 20, 59, 0, 846, DateTimeKind.Utc).AddTicks(868) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 7, 20, 59, 0, 846, DateTimeKind.Utc).AddTicks(871), new DateTime(2024, 1, 7, 20, 59, 0, 846, DateTimeKind.Utc).AddTicks(871) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 7, 20, 59, 0, 846, DateTimeKind.Utc).AddTicks(3236), new DateTime(2024, 1, 7, 20, 59, 0, 846, DateTimeKind.Utc).AddTicks(3237) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 7, 20, 59, 0, 846, DateTimeKind.Utc).AddTicks(3243), new DateTime(2024, 1, 7, 20, 59, 0, 846, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 7, 20, 59, 0, 845, DateTimeKind.Utc).AddTicks(9940), new DateTime(2024, 1, 7, 20, 59, 0, 845, DateTimeKind.Utc).AddTicks(9937) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 7, 20, 59, 0, 845, DateTimeKind.Utc).AddTicks(9944), new DateTime(2024, 1, 7, 20, 59, 0, 845, DateTimeKind.Utc).AddTicks(9944) });
        }
    }
}
