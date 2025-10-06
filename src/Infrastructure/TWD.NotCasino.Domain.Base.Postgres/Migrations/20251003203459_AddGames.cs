using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWD.NotCasino.Domain.Base.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AddGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Servers_ServerId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_GameLogs_Game_GameId",
                table: "GameLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSettings_Game_GameId",
                table: "GameSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.RenameIndex(
                name: "IX_Game_ServerId",
                table: "Games",
                newName: "IX_Games_ServerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ReloadAccounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now() at time zone 'utc'",
                comment: "Дата обновления аккаунта",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldComment: "Дата обновления аккаунта");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameLogs_Games_GameId",
                table: "GameLogs",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Servers_ServerId",
                table: "Games",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameSettings_Games_GameId",
                table: "GameSettings",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameLogs_Games_GameId",
                table: "GameLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Servers_ServerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSettings_Games_GameId",
                table: "GameSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.RenameIndex(
                name: "IX_Games_ServerId",
                table: "Game",
                newName: "IX_Game_ServerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ReloadAccounts",
                type: "timestamp with time zone",
                nullable: false,
                comment: "Дата обновления аккаунта",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now() at time zone 'utc'",
                oldComment: "Дата обновления аккаунта");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Servers_ServerId",
                table: "Game",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameLogs_Game_GameId",
                table: "GameLogs",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameSettings_Game_GameId",
                table: "GameSettings",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
