using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FEM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedFootballClubPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FootballClubsPlayers",
                columns: table => new
                {
                    FootballClubId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballClubsPlayers", x => new { x.FootballClubId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_FootballClubsPlayers_FootballClubs_FootballClubId",
                        column: x => x.FootballClubId,
                        principalTable: "FootballClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FootballClubsPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FootballClubsPlayers_PlayerId",
                table: "FootballClubsPlayers",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FootballClubsPlayers");
        }
    }
}
