using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWD.NotCasino.Domain.Base.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Coins",
                table: "Accounts",
                type: "numeric",
                nullable: false,
                defaultValue: 0.01m,
                comment: "Текущее количество монет",
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldComment: "Текущее количество монет");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Coins",
                table: "Accounts",
                type: "numeric",
                nullable: false,
                comment: "Текущее количество монет",
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldDefaultValue: 0.01m,
                oldComment: "Текущее количество монет");
        }
    }
}
