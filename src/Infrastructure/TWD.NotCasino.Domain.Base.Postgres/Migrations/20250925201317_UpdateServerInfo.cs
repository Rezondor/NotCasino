using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWD.NotCasino.Domain.Base.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class UpdateServerInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServerName",
                table: "Servers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Servers",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Название");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Servers");

            migrationBuilder.AddColumn<byte>(
                name: "ServerName",
                table: "Servers",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0,
                comment: "Сервер");
        }
    }
}
