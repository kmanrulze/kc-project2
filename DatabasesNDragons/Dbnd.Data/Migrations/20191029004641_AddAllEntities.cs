using Microsoft.EntityFrameworkCore.Migrations;

namespace Dbnd.Data.Migrations
{
    public partial class AddAllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientLogin",
                table: "Client");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Client",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Client");

            migrationBuilder.AddColumn<string>(
                name: "ClientLogin",
                table: "Client",
                type: "text",
                nullable: true);
        }
    }
}
