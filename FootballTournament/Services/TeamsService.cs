using FootballTournament.DAL;
using FootballTournament.DAL.Models;
using FootballTournament.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTournament.Services
{
    public class TeamsService
    {
        private readonly TeamRepository _teamRepository;

        public TeamsService(FootballTournamentContext context)
        {
            _teamRepository = new TeamRepository(context);
        }

        static void ShowTeam(Team team)
        {
            Console.WriteLine($"{team.Name}, {team.City}, {team.VictoriesAmount}, {team.LossesAmount}, {team.DrawsAmount}, " +
                $"{team.ScoredGoalsAmount}, {team.ConcededGoalsAmount}");
        }

        public void ShowTeams()
        {
            var teams = _teamRepository.GetTeams();
            foreach (var team in teams)
            {
                ShowTeam(team);
            }
        }

        public void ShowTeams(IEnumerable<Team> teams)
        {
            foreach (var team in teams)
            {
                ShowTeam(team);
            }
        }

        public void FindByName()
        {
            Console.WriteLine("Enter team name: ");
            var name = Console.ReadLine();
            ShowTeam(_teamRepository.FindByName(name));
        }

        public void FindByCity()
        {
            Console.WriteLine("Enter team city: ");
            var city = Console.ReadLine();
            ShowTeams(_teamRepository.FindByCity(city));
        }

        public void FindByNameAndCity()
        {
            Console.WriteLine("Enter team name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter team city: ");
            var city = Console.ReadLine();
            ShowTeam(_teamRepository.FindByNameAndCity(name, city));
        }

        public void ShowTeamWithMaxVictories()
        {
            ShowTeam(_teamRepository.TeamWithMaxVictories());
        }

        public void ShowTeamWithMaxLosses()
        {
            ShowTeam(_teamRepository.TeamWithMaxLosses());
        }

        public void ShowTeamWithMaxDraws()
        {
            ShowTeam(_teamRepository.TeamWithMaxDraws());
        }

        public void ShowTeamWithMaxScored()
        {
            ShowTeam(_teamRepository.TeamWithMaxScored());
        }

        public void ShowTeamWithMaxConceded()
        {
            ShowTeam(_teamRepository.TeamWithMaxConceded());
        }

        public void AddTeam()
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

            if(!_teamRepository.IsExists(team))
                _teamRepository.AddTeam(team);
            else
                Console.WriteLine("This team is already exists!");
        }

        public void UpdateTeam()
        {
            Console.Write("Enter name: ");
            var name = Console.ReadLine();
            Console.Write("Enter city: ");
            var city = Console.ReadLine();

            Team team = _teamRepository.FindByNameAndCity(name, city);
            if(_teamRepository.IsExists(team))
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

                if (choice < 0 || choice > 7) 
                    return;
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

                _teamRepository.UpdateTeam(team);
            }
            else
                Console.WriteLine("Team doesn't exist!");
        }

        public void DeleteTeam()
        {
            Console.Write("Enter name: ");
            var name = Console.ReadLine();
            Console.Write("Enter city: ");
            var city = Console.ReadLine();

            Team team = _teamRepository.FindByNameAndCity(name, city);
            if (_teamRepository.IsExists(team))
            {
                Console.WriteLine("Are you sure you want to delete this team?\n" +
                                "1.Yes\n" +
                                "2.No");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    _teamRepository.DeleteTeam(team);
                }
                else
                    return;
            }
            else
                Console.WriteLine("Team doesn't exist!");
        }
    }
}
