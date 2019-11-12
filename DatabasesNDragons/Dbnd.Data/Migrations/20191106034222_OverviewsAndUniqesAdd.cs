using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dbnd.Data.Migrations
{
    public partial class OverviewsAndUniqesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Game_GameName",
                table: "Game",
                column: "GameName");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Client_Email",
                table: "Client",
                column: "Email");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Client_UserName",
                table: "Client",
                column: "UserName");

            migrationBuilder.CreateTable(
                name: "OverviewType",
                columns: table => new
                {
                    TypeID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverviewType", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Overview",
                columns: table => new
                {
                    OverviewID = table.Column<Guid>(nullable: false),
                    GameID = table.Column<Guid>(nullable: false),
                    TypeID = table.Column<Guid>(nullable: false),
                    OverviewTypeTypeID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Overview", x => x.OverviewID);
                    table.ForeignKey(
                        name: "FK_Overview_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Overview_OverviewType_OverviewTypeTypeID",
                        column: x => x.OverviewTypeTypeID,
                        principalTable: "OverviewType",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Overview_GameID",
                table: "Overview",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Overview_OverviewTypeTypeID",
                table: "Overview",
                column: "OverviewTypeTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Overview");

            migrationBuilder.DropTable(
                name: "OverviewType");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Game_GameName",
                table: "Game");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Client_Email",
                table: "Client");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Client_UserName",
                table: "Client");
        }
    }
}
