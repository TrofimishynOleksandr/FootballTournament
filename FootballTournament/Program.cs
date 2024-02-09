using FootballTournament.DAL;
using FootballTournament.DAL.Models;
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
                    "1.Find team by name\n" +
                    "2.Find team by city\n" +
                    "3.Find team by name and city\n" +
                    "4.Show team with max victories\n" +
                    "5.Show team with max losses\n" +
                    "6.Show team with max draws\n" +
                    "7.Show team with max scored goals\n" +
                    "8.Show team with max conceded goals\n" +
                    "9.Add team\n" +
                    "10.Update team\n" +
                    "11.Delete team\n" +
                    "0.Exit");
                int choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        Console.WriteLine("Enter team name: ");
                        FindByName(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Enter team city: ");
                        FindByCity(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Enter team name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter team city: ");
                        FindByNameAndCity(name, Console.ReadLine());
                        break;
                    case 4:
                        ShowTeamWithMaxVictories();
                        break;
                    case 5:
                        ShowTeamWithMaxLosses();
                        break;
                    case 6:
                        ShowTeamWithMaxDraws();
                        break;
                    case 7:
                        ShowTeamWithMaxScored();
                        break;
                    case 8:
                        ShowTeamWithMaxConceded();
                        break;
                    case 9:
                        AddTeam();
                        break;
                    case 10:
                        UpdateTeam();
                        break;
                    case 11:
                        DeleteTeam();
                        break;
                }
            }
        }

        static void ShowTeam(Team team)
        {
            Console.WriteLine($"{team.Name}, {team.City}, {team.VictoriesAmount}, {team.LossesAmount}, {team.DrawsAmount}, " +
                $"{team.ScoredGoalsAmount}, {team.ConcededGoalsAmount}");
        }

        static void FindByName(string name)
        {
            using (var context = new FootballTournamentContext())
            {
                foreach(var team in context.Teams)
                {
                    if(team.Name == name)
                        ShowTeam(team);
                }
            }
        }

        static void FindByCity(string city)
        {
            using (var context = new FootballTournamentContext())
            {
                foreach (var team in context.Teams)
                {
                    if (team.City == city)
                        ShowTeam(team);
                }
            }
        }

        static void FindByNameAndCity(string name, string city)
        {
            using (var context = new FootballTournamentContext())
            {
                foreach (var team in context.Teams)
                {
                    if (team.Name == name && team.City == city)
                        ShowTeam(team);
                }
            }
        }

        static void ShowTeamWithMaxVictories()
        {
            using (var context = new FootballTournamentContext())
            {
                int maxVictories = context.Teams.Max(t => t.VictoriesAmount);
                var teamsWithMaxVictories = context.Teams.Where(t => t.VictoriesAmount == maxVictories).ToList();

                foreach( var team in teamsWithMaxVictories)
                {
                    ShowTeam(team);
                }
            }
        }

        static void ShowTeamWithMaxLosses()
        {
            using (var context = new FootballTournamentContext())
            {
                int maxLosses = context.Teams.Max(t => t.LossesAmount);
                var teamsWithMaxLosses = context.Teams.Where(t => t.LossesAmount == maxLosses).ToList();

                foreach (var team in teamsWithMaxLosses)
                {
                    ShowTeam(team);
                }
            }
        }

        static void ShowTeamWithMaxDraws()
        {
            using (var context = new FootballTournamentContext())
            {
                int maxDraws = context.Teams.Max(t => t.DrawsAmount);
                var teamsWithMaxDraws = context.Teams.Where(t => t.DrawsAmount == maxDraws).ToList();

                foreach (var team in teamsWithMaxDraws)
                {
                    ShowTeam(team);
                }
            }
        }

        static void ShowTeamWithMaxScored()
        {
            using (var context = new FootballTournamentContext())
            {
                int maxScored = context.Teams.Max(t => t.ScoredGoalsAmount);
                var teamsWithMaxScored = context.Teams.Where(t => t.ScoredGoalsAmount == maxScored).ToList();

                foreach (var team in teamsWithMaxScored)
                {
                    ShowTeam(team);
                }
            }
        }

        static void ShowTeamWithMaxConceded()
        {
            using (var context = new FootballTournamentContext())
            {
                int maxConceded = context.Teams.Max(t => t.ConcededGoalsAmount);
                var teamsWithMaxConceded = context.Teams.Where(t => t.ConcededGoalsAmount == maxConceded).ToList();

                foreach (var team in teamsWithMaxConceded)
                {
                    ShowTeam(team);
                }
            }
        }

        static void AddTeam()
        {
            Team team = new Team();

            Console.Write("Enter name: ");
            team.Name = Console.ReadLine();
            Console.Write("Enter city: ");
            team.City = Console.ReadLine();
            Console.Write("Enter victories amount: ");
            team.VictoriesAmount = int.Parse(Console.ReadLine());
            Console.Write("Enter losses amount: ");
            team.LossesAmount = int.Parse(Console.ReadLine());
            Console.Write("Enter draws amount: ");
            team.DrawsAmount = int.Parse(Console.ReadLine());
            Console.Write("Enter scored goals amount: ");
            team.ScoredGoalsAmount = int.Parse(Console.ReadLine());
            Console.Write("Enter conceded goals amount: ");
            team.ConcededGoalsAmount = int.Parse(Console.ReadLine());

            using (var context = new FootballTournamentContext())
            {
                if (!context.Teams.Any(t => t.Name == team.Name && t.City == team.City))
                {
                    context.Teams.Add(team);
                    context.SaveChanges();
                }
                else
                    Console.WriteLine("This team is already exists!");
            }
        }

        static void UpdateTeam()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter city: ");
            string city = Console.ReadLine();

            using (var context = new FootballTournamentContext())
            {
                Team team = context.Teams.FirstOrDefault(t => t.Name == name && t.City == city);
                if (team != null)
                {
                    Console.WriteLine("What do you want to update?\n" +
                        "1.Name\n" +
                        "2.City\n" +
                        "3.Victories amount\n" +
                        "4.Losses amount\n" +
                        "5.Draws amount\n" +
                        "6.Scored goals amount\n" +
                        "7.Conceded goals amount\n" +
                        "0.Exit");

                    int choice = int.Parse(Console.ReadLine());
                    if (choice < 0 || choice > 7) return;

                    Console.WriteLine("Enter new value: ");
                    switch (choice)
                    {
                        case 1:
                            team.Name = Console.ReadLine();
                            break;
                        case 2:
                            team.City = Console.ReadLine();
                            break;
                        case 3:
                            team.VictoriesAmount = int.Parse(Console.ReadLine());
                            break;
                        case 4:
                            team.LossesAmount = int.Parse(Console.ReadLine());
                            break;
                        case 5:
                            team.DrawsAmount = int.Parse(Console.ReadLine());
                            break;
                        case 6:
                            team.ScoredGoalsAmount = int.Parse(Console.ReadLine());
                            break;
                        case 7:
                            team.ConcededGoalsAmount = int.Parse(Console.ReadLine());
                            break;
                    }
                    context.Update(team);
                    context.SaveChanges();
                }
                else
                    Console.WriteLine("No such team!");
            }
        }

        static void DeleteTeam()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter city: ");
            string city = Console.ReadLine();

            using (var context = new FootballTournamentContext())
            {
                Team team = context.Teams.FirstOrDefault(t => t.Name == name && t.City == city);
                if (team != null)
                {
                    Console.WriteLine("Are you sure you want to delete this team?\n" +
                        "1.Yes\n" +
                        "2.No");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        context.Teams.Remove(team);
                        context.SaveChanges();
                    }
                    else
                        return;
                }
                else
                    Console.WriteLine("No such team!");
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
