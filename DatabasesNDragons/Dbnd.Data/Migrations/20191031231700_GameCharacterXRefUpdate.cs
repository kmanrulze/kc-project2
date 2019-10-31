using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dbnd.Data.Migrations
{
    public partial class GameCharacterXRefUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterGameXRef_Client_ClientID",
                table: "CharacterGameXRef");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterGameXRef",
                table: "CharacterGameXRef");

            migrationBuilder.DropIndex(
                name: "IX_CharacterGameXRef_ClientID",
                table: "CharacterGameXRef");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "CharacterGameXRef");

            migrationBuilder.AddColumn<Guid>(
                name: "CharacterID",
                table: "CharacterGameXRef",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterGameXRef",
                table: "CharacterGameXRef",
                columns: new[] { "GameID", "CharacterID" });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterGameXRef_CharacterID",
                table: "CharacterGameXRef",
                column: "CharacterID");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterGameXRef_Character_CharacterID",
                table: "CharacterGameXRef",
                column: "CharacterID",
                principalTable: "Character",
                principalColumn: "CharacterID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterGameXRef_Character_CharacterID",
                table: "CharacterGameXRef");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterGameXRef",
                table: "CharacterGameXRef");

            migrationBuilder.DropIndex(
                name: "IX_CharacterGameXRef_CharacterID",
                table: "CharacterGameXRef");

            migrationBuilder.DropColumn(
                name: "CharacterID",
                table: "CharacterGameXRef");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientID",
                table: "CharacterGameXRef",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterGameXRef",
                table: "CharacterGameXRef",
                columns: new[] { "GameID", "ClientID" });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterGameXRef_ClientID",
                table: "CharacterGameXRef",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterGameXRef_Client_ClientID",
                table: "CharacterGameXRef",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
