using FootballTournament.DAL;
using FootballTournament.DAL.Models;
using FootballTournament.Services;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.Design;
using System.Transactions;
using System.Xml.Linq;

namespace FootballTournament
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new FootballTournamentContext())
            {
                FillDb();
                Menu();
            }
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("Choose option:\n" +
                    "1.Show all teams\n" +
                    "2.Find team by name\n" +
                    "3.Find team by city\n" +
                    "4.Find team by name and city\n" +
                    "5.Show team with max victories\n" +
                    "6.Show team with max losses\n" +
                    "7.Show team with max draws\n" +
                    "8.Show team with max scored goals\n" +
                    "9.Show team with max conceded goals\n" +
                    "10.Add team\n" +
                    "11.Update team\n" +
                    "12.Delete team\n" +
                    "13.Show goals difference\n" +
                    "14.Show all matches\n" +
                    "15.Show match info\n" +
                    "16.Show match in current date\n" +
                    "17.Show all matches of team\n" +
                    "18.Show players scored in current date\n" +
                    "19.Add match\n" +
                    "20.Update match\n" +
                    "21.Delete match\n" +
                    "0.Exit");
                int choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > 20) return;

                using (var context = new FootballTournamentContext())
                {
                    TeamsService teamsService = new TeamsService(context);
                    MatchesService matchesService = new MatchesService(context);

                    switch (choice)
                    {
                        case 1:
                            teamsService.ShowTeams();
                            break;
                        case 2:
                            teamsService.FindByName();
                            break;
                        case 3:
                            teamsService.FindByCity();
                            break;
                        case 4:
                            teamsService.FindByNameAndCity();
                            break;
                        case 5:
                            teamsService.ShowTeamWithMaxVictories();
                            break;
                        case 6:
                            teamsService.ShowTeamWithMaxLosses();
                            break;
                        case 7:
                            teamsService.ShowTeamWithMaxDraws();
                            break;
                        case 8:
                            teamsService.ShowTeamWithMaxScored();
                            break;
                        case 9:
                            teamsService.ShowTeamWithMaxConceded();
                            break;
                        case 10:
                            teamsService.AddTeam();
                            break;
                        case 11:
                            teamsService.UpdateTeam();
                            break;
                        case 12:
                            teamsService.DeleteTeam();
                            break;
                        case 13:
                            teamsService.GoalsDifference();
                            break;
                        case 14:
                            matchesService.ShowMatches();
                            break;
                        case 15:
                            matchesService.ShowMatch();
                            break;
                        case 16:
                            matchesService.ShowMatchWithDate();
                            break;
                        case 17:
                            matchesService.ShowMatchesOfTeam();
                            break;
                        case 18:
                            matchesService.ShowPlayersScoredInDate();
                            break;
                        case 19:
                            matchesService.AddMatch();
                            break;
                        case 20:
                            matchesService.UpdateMatch();
                            break;
                        case 21:
                            matchesService.DeleteMatch();
                            break;
                    }
                }
            }
        }

        static void FillDb()
        {
            using (var context = new FootballTournamentContext())
            {
                if (context.Teams.Count() == 0)
                {
                    List<Team> teams = new List<Team>()
                    {
                        new Team() { Name = "Team1", City = "City3", VictoriesAmount = 2, LossesAmount = 1, DrawsAmount = 1, ScoredGoalsAmount = 4, ConcededGoalsAmount = 2 },
                        new Team() { Name = "Team4", City = "City2", VictoriesAmount = 5, LossesAmount = 0, DrawsAmount = 2, ScoredGoalsAmount = 12, ConcededGoalsAmount = 3 },
                        new Team() { Name = "Team2", City = "City3", VictoriesAmount = 3, LossesAmount = 4, DrawsAmount = 4, ScoredGoalsAmount = 5, ConcededGoalsAmount = 7 },
                        new Team() { Name = "Team3", City = "City1", VictoriesAmount = 7, LossesAmount = 3, DrawsAmount = 2, ScoredGoalsAmount = 15, ConcededGoalsAmount = 5 }
                    };

                    context.Teams.AddRange(teams);
                    context.SaveChanges();
                }

                if (context.Players.Count() == 0)
                {
                    List<Player> players = new List<Player>()
                    {
                        new Player() { FullName = "Player2", Country = "Country3", Number = 7, Position = "ST", Team = context.Teams.ToList()[3]},
                        new Player() { FullName = "Player3", Country = "Country2", Number = 2, Position = "LW", Team = context.Teams.ToList()[2]},
                        new Player() { FullName = "Player5", Country = "Country3", Number = 17, Position = "RW", Team = context.Teams.ToList()[1]},
                        new Player() { FullName = "Player1", Country = "Country5", Number = 13, Position = "CT", Team = context.Teams.ToList()[0]},
                        new Player() { FullName = "Player4", Country = "Country1", Number = 21, Position = "GK", Team = context.Teams.ToList()[3]},
                        new Player() { FullName = "Player6", Country = "Country2", Number = 3, Position = "ST", Team = context.Teams.ToList()[2]},
                        new Player() { FullName = "Player8", Country = "Country4", Number = 1, Position = "GK", Team = context.Teams.ToList()[1]},
                        new Player() { FullName = "Player7", Country = "Country5", Number = 10, Position = "CT", Team = context.Teams.ToList()[0]}
                    };

                    context.Players.AddRange(players);
                    context.SaveChanges();
                }

                if (context.Matches.Count() == 0)
                {
                    List<Match> matches = new List<Match>()
                    {
                        new Match() {Team1 = context.Teams.ToList()[0], Team2 = context.Teams.ToList()[3], Team1Score = 3, Team2Score = 4, Date = new DateTime(2024, 1, 5), 
                            PlayersScored = new List<Player>(){context.Players.ToList()[0], context.Players.ToList()[3], context.Players.ToList()[4], context.Players.ToList()[7] } },
                        new Match() {Team1 = context.Teams.ToList()[3], Team2 = context.Teams.ToList()[1], Team1Score = 4, Team2Score = 1, Date = new DateTime(2024, 1, 15),
                            PlayersScored = new List<Player>(){context.Players.ToList()[0], context.Players.ToList()[2], context.Players.ToList()[4] }},
                        new Match() {Team1 = context.Teams.ToList()[1], Team2 = context.Teams.ToList()[2], Team1Score = 1, Team2Score = 0, Date = new DateTime(2023, 12, 13),
                            PlayersScored = new List<Player>(){context.Players.ToList()[2] }},
                        new Match() {Team1 = context.Teams.ToList()[0], Team2 = context.Teams.ToList()[2], Team1Score = 2, Team2Score = 3, Date = new DateTime(2023, 12, 6),
                            PlayersScored = new List<Player>(){context.Players.ToList()[1], context.Players.ToList()[3], context.Players.ToList()[5], context.Players.ToList()[7] }}
                    };

                    context.Matches.AddRange(matches);
                    context.SaveChanges();
                }


            }
        }
    }
}
