using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FEM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedMatchStatistics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatchesStatistics",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Corners = table.Column<byte>(type: "tinyint", nullable: false),
                    Posession = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchesStatistics", x => new { x.MatchId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_MatchesStatistics_FootballClubs_TeamId",
                        column: x => x.TeamId,
                        principalTable: "FootballClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchesStatistics_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchesStatistics_TeamId",
                table: "MatchesStatistics",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchesStatistics");
        }
    }
}
