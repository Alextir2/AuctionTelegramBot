using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionBot.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnNameInTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_State_StateId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserAuctions",
                type: "text",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Auctions",
                type: "text",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "States",
                type: "text",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 22, 19, 18, 11, 637, DateTimeKind.Utc).AddTicks(5657), new DateTime(2024, 1, 22, 19, 18, 11, 637, DateTimeKind.Utc).AddTicks(5657) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 22, 19, 18, 11, 637, DateTimeKind.Utc).AddTicks(5660), new DateTime(2024, 1, 22, 19, 18, 11, 637, DateTimeKind.Utc).AddTicks(5660) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 22, 19, 18, 11, 637, DateTimeKind.Utc).AddTicks(7747), new DateTime(2024, 1, 22, 19, 18, 11, 637, DateTimeKind.Utc).AddTicks(7748) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 22, 19, 18, 11, 637, DateTimeKind.Utc).AddTicks(7755), new DateTime(2024, 1, 22, 19, 18, 11, 637, DateTimeKind.Utc).AddTicks(7756) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDt", "TelegramUserChatId", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 22, 19, 18, 11, 637, DateTimeKind.Utc).AddTicks(4781), 426772147L, new DateTime(2024, 1, 22, 19, 18, 11, 637, DateTimeKind.Utc).AddTicks(4780) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "TelegramUserChatId", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 22, 19, 18, 11, 637, DateTimeKind.Utc).AddTicks(4787), 1376808954L, new DateTime(2024, 1, 22, 19, 18, 11, 637, DateTimeKind.Utc).AddTicks(4786) });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_States_StateId",
                table: "Users",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_States_StateId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserAuctions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "States");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "Id");

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
                columns: new[] { "CreateDt", "TelegramUserChatId", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 20, 13, 40, 9, 822, DateTimeKind.Utc).AddTicks(5841), 1L, new DateTime(2024, 1, 20, 13, 40, 9, 822, DateTimeKind.Utc).AddTicks(5837) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDt", "TelegramUserChatId", "UpdateDt" },
                values: new object[] { new DateTime(2024, 1, 20, 13, 40, 9, 822, DateTimeKind.Utc).AddTicks(5845), 2L, new DateTime(2024, 1, 20, 13, 40, 9, 822, DateTimeKind.Utc).AddTicks(5844) });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_State_StateId",
                table: "Users",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id");
        }
    }
}
