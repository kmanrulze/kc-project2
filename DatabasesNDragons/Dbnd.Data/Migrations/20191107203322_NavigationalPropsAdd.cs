using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dbnd.Data.Migrations
{
    public partial class NavigationalPropsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CharacterID",
                table: "Game",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GameID",
                table: "Character",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_CharacterID",
                table: "Game",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_Character_GameID",
                table: "Character",
                column: "GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Game_GameID",
                table: "Character",
                column: "GameID",
                principalTable: "Game",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Character_CharacterID",
                table: "Game",
                column: "CharacterID",
                principalTable: "Character",
                principalColumn: "CharacterID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Game_GameID",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Character_CharacterID",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_CharacterID",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Character_GameID",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "CharacterID",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "GameID",
                table: "Character");
        }
    }
}
