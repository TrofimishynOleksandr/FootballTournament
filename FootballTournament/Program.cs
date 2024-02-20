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
                new FootballTournamentService(context).FillDb();
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
                    "22.Show top 3 bombardiers of team\n" +
                    "23.Show top 1 bombardier of team\n" +
                    "24.Show top 3 bombardiers of tournament\n" +
                    "25.Show top 1 bombardier of tournament\n" +
                    "26.Show top 3 teams with max scored\n" +
                    "27.Show top 1 team with max scored\n" +
                    "28.Show top 3 teams with min conceded\n" +
                    "29.Show top 1 team with min conceded\n" +
                    "30.Show top 3 teams with max points\n" +
                    "31.Show top 1 team with max points\n" +
                    "32.Show top 3 teams with min points\n" +
                    "33.Show top 1 team with min points\n" +
                    "0.Exit");
                int choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > 33) return;

                using (var context = new FootballTournamentContext())
                {
                    FootballTournamentService footballTournamentService = new FootballTournamentService(context);

                    switch (choice)
                    {
                        case 1:
                            footballTournamentService.ShowTeams();
                            break;
                        case 2:
                            footballTournamentService.FindByName();
                            break;
                        case 3:
                            footballTournamentService.FindByCity();
                            break;
                        case 4:
                            footballTournamentService.FindByNameAndCity();
                            break;
                        case 5:
                            footballTournamentService.ShowTeamWithMaxVictories();
                            break;
                        case 6:
                            footballTournamentService.ShowTeamWithMaxLosses();
                            break;
                        case 7:
                            footballTournamentService.ShowTeamWithMaxDraws();
                            break;
                        case 8:
                            footballTournamentService.ShowTeamWithMaxScored();
                            break;
                        case 9:
                            footballTournamentService.ShowTeamWithMaxConceded();
                            break;
                        case 10:
                            footballTournamentService.AddTeam();
                            break;
                        case 11:
                            footballTournamentService.UpdateTeam();
                            break;
                        case 12:
                            footballTournamentService.DeleteTeam();
                            break;
                        case 13:
                            footballTournamentService.GoalsDifference();
                            break;
                        case 14:
                            footballTournamentService.ShowMatches();
                            break;
                        case 15:
                            footballTournamentService.ShowMatch();
                            break;
                        case 16:
                            footballTournamentService.ShowMatchWithDate();
                            break;
                        case 17:
                            footballTournamentService.ShowMatchesOfTeam();
                            break;
                        case 18:
                            footballTournamentService.ShowPlayersScoredInDate();
                            break;
                        case 19:
                            footballTournamentService.AddMatch();
                            break;
                        case 20:
                            footballTournamentService.UpdateMatch();
                            break;
                        case 21:
                            footballTournamentService.DeleteMatch();
                            break;
                        case 22:
                            footballTournamentService.SelectTopBombardiersOfTeam(3);
                            break;
                        case 23:
                            footballTournamentService.SelectTopBombardiersOfTeam(1);
                            break;
                        case 24:
                            footballTournamentService.SelectTopBombardiersOfTournament(3);
                            break;
                        case 25:
                            footballTournamentService.SelectTopBombardiersOfTournament(1);
                            break;
                        case 26:
                            footballTournamentService.SelectTeamsWithMaxScored(3);
                            break;
                        case 27:
                            footballTournamentService.SelectTeamsWithMaxScored(1);
                            break;
                        case 28:
                            footballTournamentService.SelectTeamsWithMinConceded(3);
                            break;
                        case 29:
                            footballTournamentService.SelectTeamsWithMinConceded(1);
                            break;
                        case 30:
                            footballTournamentService.SelectTeamsWithMaxPoints(3);
                            break;
                        case 31:
                            footballTournamentService.SelectTeamsWithMaxPoints(1);
                            break;
                        case 32:
                            footballTournamentService.SelectTeamsWithMinPoints(3);
                            break;
                        case 33:
                            footballTournamentService.SelectTeamsWithMinPoints(1);
                            break;
                    }
                }
            }
        }
    }
}
