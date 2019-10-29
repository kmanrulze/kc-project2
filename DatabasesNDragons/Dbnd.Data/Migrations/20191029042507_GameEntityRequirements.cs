using Microsoft.EntityFrameworkCore.Migrations;

namespace Dbnd.Data.Migrations
{
    public partial class GameEntityRequirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GameName",
                table: "Game",
                maxLength: 225,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CharacterLastName",
                table: "Character",
                maxLength: 75,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CharacterFirstName",
                table: "Character",
                maxLength: 75,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GameName",
                table: "Game",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 225);

            migrationBuilder.AlterColumn<string>(
                name: "CharacterLastName",
                table: "Character",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 75);

            migrationBuilder.AlterColumn<string>(
                name: "CharacterFirstName",
                table: "Character",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 75);
        }
    }
}
