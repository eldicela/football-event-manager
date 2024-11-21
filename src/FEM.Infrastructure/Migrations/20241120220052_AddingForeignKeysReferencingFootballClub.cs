using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FEM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingForeignKeysReferencingFootballClub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team1",
                table: "Matches",
                column: "Team1");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team2",
                table: "Matches",
                column: "Team2");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_FootballClubs_Team1",
                table: "Matches",
                column: "Team1",
                principalTable: "FootballClubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_FootballClubs_Team2",
                table: "Matches",
                column: "Team2",
                principalTable: "FootballClubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_FootballClubs_Team1",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_FootballClubs_Team2",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Team1",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Team2",
                table: "Matches");
        }
    }
}
