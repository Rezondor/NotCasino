using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWD.NotCasino.Domain.Base.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class FixUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameLogs_Users_UserId",
                table: "GameLogs");

            migrationBuilder.DropIndex(
                name: "IX_GameLogs_UserId",
                table: "GameLogs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GameLogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "GameLogs",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameLogs_UserId",
                table: "GameLogs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameLogs_Users_UserId",
                table: "GameLogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
