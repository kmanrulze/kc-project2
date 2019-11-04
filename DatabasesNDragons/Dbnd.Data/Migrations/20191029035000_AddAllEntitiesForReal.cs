using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dbnd.Data.Migrations
{
    public partial class AddAllEntitiesForReal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Client",
                maxLength: 75,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Client",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Client",
                maxLength: 75,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<Guid>(nullable: false),
                    CharacterFirstName = table.Column<string>(nullable: true),
                    CharacterLastName = table.Column<string>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Character_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DungeonMaster",
                columns: table => new
                {
                    DungeonMasterId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DungeonMaster", x => x.DungeonMasterId);
                    table.ForeignKey(
                        name: "FK_DungeonMaster_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameId = table.Column<Guid>(nullable: false),
                    GameName = table.Column<string>(nullable: true),
                    DungeonMasterId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Game_DungeonMaster_DungeonMasterId",
                        column: x => x.DungeonMasterId,
                        principalTable: "DungeonMaster",
                        principalColumn: "DungeonMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterGameXRef",
                columns: table => new
                {
                    GameId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterGameXRef", x => new { x.GameId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_CharacterGameXRef_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterGameXRef_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_ClientId",
                table: "Character",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterGameXRef_ClientId",
                table: "CharacterGameXRef",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DungeonMaster_ClientId",
                table: "DungeonMaster",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_DungeonMasterId",
                table: "Game",
                column: "DungeonMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "CharacterGameXRef");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "DungeonMaster");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 75);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 75);
        }
    }
}
