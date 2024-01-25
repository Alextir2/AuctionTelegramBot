using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AuctionBot.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddTableState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TelegramCommand = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

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
                columns: new[] { "CreateDt", "StateId", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 7, 20, 59, 0, 845, DateTimeKind.Utc).AddTicks(9940), null, new DateTime(2024, 1, 7, 20, 59, 0, 845, DateTimeKind.Utc).AddTicks(9937) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "StateId", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 7, 20, 59, 0, 845, DateTimeKind.Utc).AddTicks(9944), null, new DateTime(2024, 1, 7, 20, 59, 0, 845, DateTimeKind.Utc).AddTicks(9944) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_StateId",
                table: "Users",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_State_StateId",
                table: "Users",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_State_StateId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropIndex(
                name: "IX_Users_StateId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Users");

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
    }
}
