using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballTournament.DAL.Migrations
{
    public partial class AddAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_Team1Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_Team2Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_TeamId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayer_Matches_MatchesId",
                table: "MatchPlayer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.RenameTable(
                name: "Matches",
                newName: "TournamentMatches");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Teams",
                newName: "TeamName");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Teams",
                newName: "TeamCity");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TournamentMatches",
                newName: "DateOfMatch");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_TeamId",
                table: "TournamentMatches",
                newName: "IX_TournamentMatches_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_Team2Id",
                table: "TournamentMatches",
                newName: "IX_TournamentMatches_Team2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_Team1Id",
                table: "TournamentMatches",
                newName: "IX_TournamentMatches_Team1Id");

            migrationBuilder.AlterColumn<string>(
                name: "TeamName",
                table: "Teams",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TeamCity",
                table: "Teams",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Players",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfMatch",
                table: "TournamentMatches",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TournamentMatches",
                table: "TournamentMatches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayer_TournamentMatches_MatchesId",
                table: "MatchPlayer",
                column: "MatchesId",
                principalTable: "TournamentMatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentMatches_Teams_Team1Id",
                table: "TournamentMatches",
                column: "Team1Id",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentMatches_Teams_Team2Id",
                table: "TournamentMatches",
                column: "Team2Id",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentMatches_Teams_TeamId",
                table: "TournamentMatches",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayer_TournamentMatches_MatchesId",
                table: "MatchPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentMatches_Teams_Team1Id",
                table: "TournamentMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentMatches_Teams_Team2Id",
                table: "TournamentMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentMatches_Teams_TeamId",
                table: "TournamentMatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TournamentMatches",
                table: "TournamentMatches");

            migrationBuilder.RenameTable(
                name: "TournamentMatches",
                newName: "Matches");

            migrationBuilder.RenameColumn(
                name: "TeamName",
                table: "Teams",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TeamCity",
                table: "Teams",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "DateOfMatch",
                table: "Matches",
                newName: "Date");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentMatches_TeamId",
                table: "Matches",
                newName: "IX_Matches_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentMatches_Team2Id",
                table: "Matches",
                newName: "IX_Matches_Team2Id");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentMatches_Team1Id",
                table: "Matches",
                newName: "IX_Matches_Team1Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Matches",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_Team1Id",
                table: "Matches",
                column: "Team1Id",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_Team2Id",
                table: "Matches",
                column: "Team2Id",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_TeamId",
                table: "Matches",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayer_Matches_MatchesId",
                table: "MatchPlayer",
                column: "MatchesId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
