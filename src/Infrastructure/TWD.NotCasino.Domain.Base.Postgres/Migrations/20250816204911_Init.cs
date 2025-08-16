using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TWD.NotCasino.Domain.Base.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id записи")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServerName = table.Column<byte>(type: "smallint", nullable: false, comment: "Сервер"),
                    Coins = table.Column<decimal>(type: "numeric", nullable: false, comment: "Количество монет")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                },
                comment: "Настройки серверов");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id записи")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NickName = table.Column<string>(type: "text", nullable: false, comment: "Никнейм"),
                    Login = table.Column<string>(type: "text", nullable: false, comment: "Логин"),
                    Email = table.Column<string>(type: "text", nullable: false, comment: "Почта"),
                    Password = table.Column<string>(type: "text", nullable: false, comment: "Хеш пароль"),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, comment: "Удалён ли"),
                    IsBlocked = table.Column<bool>(type: "boolean", nullable: false, comment: "Заблокирован ли")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                },
                comment: "Пользователи");

            migrationBuilder.CreateTable(
                name: "GameSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id записи")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServerId = table.Column<long>(type: "bigint", nullable: false, comment: "Id сервера"),
                    GameType = table.Column<byte>(type: "smallint", nullable: false, comment: "Тип игры"),
                    GameSettingType = table.Column<byte>(type: "smallint", nullable: false, comment: "Тип настройки"),
                    Value = table.Column<string>(type: "text", nullable: false, comment: "Значение настройки")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameSettings_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Настройки игр");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id записи")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "Id пользователя"),
                    Coins = table.Column<decimal>(type: "numeric", nullable: false, comment: "Текущее количество монет"),
                    LosesMoneyCount = table.Column<decimal>(type: "numeric", nullable: false, comment: "Общее количество проигранных монет")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Аккаунты пользователя");

            migrationBuilder.CreateTable(
                name: "ReloadAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id записи")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "Id пользователя"),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Дата обновления аккаунта")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReloadAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReloadAccounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Обновления аккаунтов");

            migrationBuilder.CreateTable(
                name: "GameLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id записи")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReloadAccountId = table.Column<long>(type: "bigint", nullable: false, comment: "Id обновления аккаунта"),
                    ServerId = table.Column<long>(type: "bigint", nullable: false, comment: "Id сервера"),
                    Bet = table.Column<int>(type: "integer", nullable: false, comment: "Ставка"),
                    Win = table.Column<int>(type: "integer", nullable: false, comment: "Выигрыш"),
                    GameType = table.Column<byte>(type: "smallint", nullable: false, comment: "Тип игры"),
                    GameData = table.Column<string>(type: "text", nullable: false, comment: "Доп информация об игре"),
                    Result = table.Column<byte>(type: "smallint", nullable: false, comment: "Результат игры"),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameLogs_ReloadAccounts_ReloadAccountId",
                        column: x => x.ReloadAccountId,
                        principalTable: "ReloadAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameLogs_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                },
                comment: "Логи игр");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameLogs_ReloadAccountId",
                table: "GameLogs",
                column: "ReloadAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GameLogs_ServerId",
                table: "GameLogs",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameLogs_UserId",
                table: "GameLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSettings_ServerId",
                table: "GameSettings",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReloadAccounts_CreateDate",
                table: "ReloadAccounts",
                column: "CreateDate");

            migrationBuilder.CreateIndex(
                name: "IX_ReloadAccounts_UserId",
                table: "ReloadAccounts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "GameLogs");

            migrationBuilder.DropTable(
                name: "GameSettings");

            migrationBuilder.DropTable(
                name: "ReloadAccounts");

            migrationBuilder.DropTable(
                name: "Servers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
