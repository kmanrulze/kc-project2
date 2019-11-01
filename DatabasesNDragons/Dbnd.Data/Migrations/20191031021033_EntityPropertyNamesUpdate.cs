using Microsoft.EntityFrameworkCore.Migrations;

namespace Dbnd.Data.Migrations
{
    public partial class EntityPropertyNamesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Client_ClientId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterGameXRef_Client_ClientId",
                table: "CharacterGameXRef");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterGameXRef_Game_GameId",
                table: "CharacterGameXRef");

            migrationBuilder.DropForeignKey(
                name: "FK_DungeonMaster_Client_ClientId",
                table: "DungeonMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_DungeonMaster_DungeonMasterId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "CharacterFirstName",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "CharacterLastName",
                table: "Character");

            migrationBuilder.RenameColumn(
                name: "DungeonMasterId",
                table: "Game",
                newName: "DungeonMasterID");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Game",
                newName: "GameID");

            migrationBuilder.RenameIndex(
                name: "IX_Game_DungeonMasterId",
                table: "Game",
                newName: "IX_Game_DungeonMasterID");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "DungeonMaster",
                newName: "ClientID");

            migrationBuilder.RenameColumn(
                name: "DungeonMasterId",
                table: "DungeonMaster",
                newName: "DungeonMasterID");

            migrationBuilder.RenameIndex(
                name: "IX_DungeonMaster_ClientId",
                table: "DungeonMaster",
                newName: "IX_DungeonMaster_ClientID");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Client",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Client",
                newName: "ClientID");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "CharacterGameXRef",
                newName: "ClientID");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "CharacterGameXRef",
                newName: "GameID");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterGameXRef_ClientId",
                table: "CharacterGameXRef",
                newName: "IX_CharacterGameXRef_ClientID");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Character",
                newName: "ClientID");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "Character",
                newName: "CharacterID");

            migrationBuilder.RenameIndex(
                name: "IX_Character_ClientId",
                table: "Character",
                newName: "IX_Character_ClientID");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Character",
                maxLength: 75,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Character",
                maxLength: 75,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Client_ClientID",
                table: "Character",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterGameXRef_Client_ClientID",
                table: "CharacterGameXRef",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterGameXRef_Game_GameID",
                table: "CharacterGameXRef",
                column: "GameID",
                principalTable: "Game",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DungeonMaster_Client_ClientID",
                table: "DungeonMaster",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_DungeonMaster_DungeonMasterID",
                table: "Game",
                column: "DungeonMasterID",
                principalTable: "DungeonMaster",
                principalColumn: "DungeonMasterID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Client_ClientID",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterGameXRef_Client_ClientID",
                table: "CharacterGameXRef");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterGameXRef_Game_GameID",
                table: "CharacterGameXRef");

            migrationBuilder.DropForeignKey(
                name: "FK_DungeonMaster_Client_ClientID",
                table: "DungeonMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_DungeonMaster_DungeonMasterID",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Character");

            migrationBuilder.RenameColumn(
                name: "DungeonMasterID",
                table: "Game",
                newName: "DungeonMasterId");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Game",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_DungeonMasterID",
                table: "Game",
                newName: "IX_Game_DungeonMasterId");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "DungeonMaster",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "DungeonMasterID",
                table: "DungeonMaster",
                newName: "DungeonMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_DungeonMaster_ClientID",
                table: "DungeonMaster",
                newName: "IX_DungeonMaster_ClientId");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Client",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Client",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "CharacterGameXRef",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "CharacterGameXRef",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterGameXRef_ClientID",
                table: "CharacterGameXRef",
                newName: "IX_CharacterGameXRef_ClientId");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Character",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "CharacterID",
                table: "Character",
                newName: "CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_Character_ClientID",
                table: "Character",
                newName: "IX_Character_ClientId");

            migrationBuilder.AddColumn<string>(
                name: "CharacterFirstName",
                table: "Character",
                type: "character varying(75)",
                maxLength: 75,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CharacterLastName",
                table: "Character",
                type: "character varying(75)",
                maxLength: 75,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Client_ClientId",
                table: "Character",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterGameXRef_Client_ClientId",
                table: "CharacterGameXRef",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterGameXRef_Game_GameId",
                table: "CharacterGameXRef",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DungeonMaster_Client_ClientId",
                table: "DungeonMaster",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_DungeonMaster_DungeonMasterId",
                table: "Game",
                column: "DungeonMasterId",
                principalTable: "DungeonMaster",
                principalColumn: "DungeonMasterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
