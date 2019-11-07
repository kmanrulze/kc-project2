using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dbnd.Data.Migrations
{
    public partial class DungMasterRemovalv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_DungeonMaster_DungeonMasterID",
                table: "Game");

            migrationBuilder.DropTable(
                name: "DungeonMaster");

            migrationBuilder.DropIndex(
                name: "IX_Game_DungeonMasterID",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "DungeonMasterID",
                table: "Game");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientID",
                table: "Game",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Game_ClientID",
                table: "Game",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Client_ClientID",
                table: "Game",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Client_ClientID",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_ClientID",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Game");

            migrationBuilder.AddColumn<Guid>(
                name: "DungeonMasterID",
                table: "Game",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DungeonMaster",
                columns: table => new
                {
                    DungeonMasterID = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DungeonMaster", x => x.DungeonMasterID);
                    table.ForeignKey(
                        name: "FK_DungeonMaster_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_DungeonMasterID",
                table: "Game",
                column: "DungeonMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_DungeonMaster_ClientID",
                table: "DungeonMaster",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_DungeonMaster_DungeonMasterID",
                table: "Game",
                column: "DungeonMasterID",
                principalTable: "DungeonMaster",
                principalColumn: "DungeonMasterID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
