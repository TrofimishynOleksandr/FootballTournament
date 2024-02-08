using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballTournament.DAL.Migrations
{
    public partial class AddScoredAndConcededGoalsAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConcededGoalsAmount",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScoredGoalsAmount",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcededGoalsAmount",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ScoredGoalsAmount",
                table: "Teams");
        }
    }
}
