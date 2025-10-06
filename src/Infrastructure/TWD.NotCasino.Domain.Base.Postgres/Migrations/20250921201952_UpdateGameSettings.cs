using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TWD.NotCasino.Domain.Base.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGameSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameLogs_Servers_ServerId",
                table: "GameLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSettings_Servers_ServerId",
                table: "GameSettings");

            migrationBuilder.DropIndex(
                name: "IX_GameSettings_ServerId",
                table: "GameSettings");

            migrationBuilder.DropIndex(
                name: "IX_GameLogs_ServerId",
                table: "GameLogs");

            migrationBuilder.DropColumn(
                name: "GameType",
                table: "GameSettings");

            migrationBuilder.DropColumn(
                name: "ServerId",
                table: "GameSettings");

            migrationBuilder.DropColumn(
                name: "GameType",
                table: "GameLogs");

            migrationBuilder.DropColumn(
                name: "ServerId",
                table: "GameLogs");

            migrationBuilder.AddColumn<long>(
                name: "GameId",
                table: "GameSettings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                comment: "Id игры");

            migrationBuilder.AlterColumn<decimal>(
                name: "Win",
                table: "GameLogs",
                type: "numeric",
                nullable: false,
                comment: "Выигрыш",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Выигрыш");

            migrationBuilder.AlterColumn<decimal>(
                name: "Bet",
                table: "GameLogs",
                type: "numeric",
                nullable: false,
                comment: "Ставка",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Ставка");

            migrationBuilder.AddColumn<long>(
                name: "GameId",
                table: "GameLogs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                comment: "Id игры");

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id записи")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServerId = table.Column<long>(type: "bigint", nullable: false, comment: "Id сервера"),
                    Type = table.Column<byte>(type: "smallint", nullable: false, comment: "Тип игры"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Наименование игры"),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "Активна ли игра")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Игры");

            migrationBuilder.CreateIndex(
                name: "IX_GameSettings_GameId",
                table: "GameSettings",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameLogs_GameId",
                table: "GameLogs",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ServerId",
                table: "Game",
                column: "ServerId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameLogs_Game_GameId",
                table: "GameLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSettings_Game_GameId",
                table: "GameSettings");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropIndex(
                name: "IX_GameSettings_GameId",
                table: "GameSettings");

            migrationBuilder.DropIndex(
                name: "IX_GameLogs_GameId",
                table: "GameLogs");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameSettings");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameLogs");

            migrationBuilder.AddColumn<byte>(
                name: "GameType",
                table: "GameSettings",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0,
                comment: "Тип игры");

            migrationBuilder.AddColumn<long>(
                name: "ServerId",
                table: "GameSettings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                comment: "Id сервера");

            migrationBuilder.AlterColumn<int>(
                name: "Win",
                table: "GameLogs",
                type: "integer",
                nullable: false,
                comment: "Выигрыш",
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldComment: "Выигрыш");

            migrationBuilder.AlterColumn<int>(
                name: "Bet",
                table: "GameLogs",
                type: "integer",
                nullable: false,
                comment: "Ставка",
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldComment: "Ставка");

            migrationBuilder.AddColumn<byte>(
                name: "GameType",
                table: "GameLogs",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0,
                comment: "Тип игры");

            migrationBuilder.AddColumn<long>(
                name: "ServerId",
                table: "GameLogs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                comment: "Id сервера");

            migrationBuilder.CreateIndex(
                name: "IX_GameSettings_ServerId",
                table: "GameSettings",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameLogs_ServerId",
                table: "GameLogs",
                column: "ServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameLogs_Servers_ServerId",
                table: "GameLogs",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameSettings_Servers_ServerId",
                table: "GameSettings",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
