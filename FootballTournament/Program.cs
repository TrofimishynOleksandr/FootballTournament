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
                if(context.Teams.Count() == 0)
                {
                    FillDb();
                    Console.WriteLine("Data added");
                }

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
                    "0.Exit");
                int choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > 11) return;

                using (var context = new FootballTournamentContext())
                {
                    TeamsService teamsService = new TeamsService(context);

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
                    }
                }
            }
        }

        static void FillDb()
        {
            List<Team> teams = new List<Team>()
            {
                new Team() { Name = "Team1", City = "City3", VictoriesAmount = 2, LossesAmount = 1, DrawsAmount = 1 },
                new Team() { Name = "Team4", City = "City2", VictoriesAmount = 5, LossesAmount = 0, DrawsAmount = 2 },
                new Team() { Name = "Team2", City = "City3", VictoriesAmount = 3, LossesAmount = 4, DrawsAmount = 4 },
                new Team() { Name = "Team3", City = "City1", VictoriesAmount = 7, LossesAmount = 3, DrawsAmount = 2 }
            };

            using (var context = new FootballTournamentContext())
            {
                context.Teams.AddRange(teams);

                context.SaveChanges();
            }
        }
    }
}
