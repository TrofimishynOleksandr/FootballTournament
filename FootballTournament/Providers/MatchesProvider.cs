using FootballTournament.DAL;
using FootballTournament.DAL.Models;
using FootballTournament.DAL.Repositories;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Match = FootballTournament.DAL.Models.Match;

namespace FootballTournament.Providers
{
    public class MatchesProvider
    {
        private readonly MatchRepository _matchRepository;
        private readonly TeamRepository _teamRepository;

        public MatchesProvider(FootballTournamentContext context)
        {
            _matchRepository = new MatchRepository(context);
            _teamRepository = new TeamRepository(context);
        }

        public void ShowMatch(Match match)
        {
            Console.WriteLine($"{match.Team1.Name} vs {match.Team2.Name} {match.Team1Score}-{match.Team2Score} {match.Date}");
        }

        public void ShowMatch()
        {
            Match match = new Match();

            Console.Write("Enter team 1 name: ");
            match.Team1 = new Team();
            match.Team1.Name = Console.ReadLine();
            Console.Write("Enter team 2 name: ");
            match.Team2 = new Team();
            match.Team2.Name = Console.ReadLine();
            Console.Write("Enter date: ");
            match.Date = DateTime.Parse(Console.ReadLine());

            match = _matchRepository.FindMatch(match);
            if (match != null && _matchRepository.IsExists(match))
            {
                ShowMatch(match);
            }
            else
                Console.WriteLine("Match doesn't exist!");
        }

        public void ShowMatches()
        {
            var matches = _matchRepository.GetMatches().ToList();
            foreach (var match in matches)
            {
                ShowMatch(match);
            }
        }

        public void ShowMatches(IEnumerable<Match> matches)
        {
            foreach (Match match in matches)
            {
                ShowMatch(match);
            }
        }

        public void ShowMatchWithDate()
        {
            Console.WriteLine("Enter date: ");
            var date = DateTime.Parse(Console.ReadLine());
            if (date != null)
                ShowMatches(_matchRepository.MatchesWithDate(date));
            else
                Console.WriteLine("Wrong date!");
        }

        public void ShowMatchesOfTeam()
        {
            Console.WriteLine("Enter team name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter team city: ");
            var city = Console.ReadLine();

            var team = _teamRepository.FindByNameAndCity(name, city);

            if (team != null)
            {
                ShowMatches(_matchRepository.MatchesWithTeam(team));
            }
        }

        public void ShowPlayer(Player player)
        {
            Console.WriteLine($"{player.FullName}, {player.Country}, {player.Number}, {player.Position}, {player.Team.Name}");
        }

        public void ShowPlayersScoredInDate()
        {
            Console.WriteLine("Enter date:");
            DateTime date = DateTime.Parse(Console.ReadLine());
            foreach (var match in _matchRepository.MatchesWithDate(date))
            {
                foreach (var player in match.PlayersScored)
                {
                    ShowPlayer(player);
                }
            }
        }

        public void AddMatch()
        {
            Match match = new Match();

            Console.Write("Enter team 1 name: ");
            var team1 = Console.ReadLine();
            match.Team1 = _teamRepository.FindByName(team1);
            Console.Write("Enter team 2 name: ");
            var team2 = Console.ReadLine();
            match.Team2 = _teamRepository.FindByName(team2);
            Console.Write("Enter team 1 score: ");
            match.Team1Score = int.Parse(Console.ReadLine());
            Console.Write("Enter team 2 score: ");
            match.Team2Score = int.Parse(Console.ReadLine());
            Console.Write("Enter date: ");
            match.Date = DateTime.Parse(Console.ReadLine());

            if (!_matchRepository.IsExistsWithId(match))
                if (_teamRepository.IsExistsWithId(match.Team1Id) && _teamRepository.IsExistsWithId(match.Team2Id))
                {
                    if (match.Team1Id != match.Team2Id)
                        _matchRepository.AddMatch(match);
                    else
                        Console.WriteLine("Teams can't be same!");
                }
                else
                    Console.WriteLine("Teams doesn't exist!");
            else
                Console.WriteLine("This match is already exists!");
        }

        public void UpdateMatch()
        {
            Match match = new Match();

            Console.Write("Enter team 1 name: ");
            var team1 = Console.ReadLine();
            match.Team1 = _teamRepository.FindByName(team1);
            Console.Write("Enter team 2 name: ");
            var team2 = Console.ReadLine();
            match.Team2 = _teamRepository.FindByName(team2);
            Console.Write("Enter date: ");
            match.Date = DateTime.Parse(Console.ReadLine());

            match = _matchRepository.FindMatch(match);
            if (match != null && _matchRepository.IsExistsWithId(match))
            {
                Console.WriteLine("What do you want to update?\n" +
                        "1.Team 1 id\n" +
                        "2.Team 2 id\n" +
                        "3.Team 1 score\n" +
                        "4.Team 1 score\n" +
                        "5.Date\n" +
                        "0.Exit");
                int choice = int.Parse(Console.ReadLine());

                if (choice < 1 || choice > 5)
                    return;
                Console.WriteLine("Enter new value: ");
                switch (choice)
                {
                    case 1:
                        match.Team1Id = int.Parse(Console.ReadLine());
                        break;
                    case 2:
                        match.Team2Id = int.Parse(Console.ReadLine());
                        break;
                    case 3:
                        match.Team1Score = int.Parse(Console.ReadLine());
                        break;
                    case 4:
                        match.Team2Score = int.Parse(Console.ReadLine());
                        break;
                    case 5:
                        match.Date = DateTime.Parse(Console.ReadLine());
                        break;
                }
                if (_teamRepository.IsExistsWithId(match.Team1Id) && _teamRepository.IsExistsWithId(match.Team2Id))
                {
                    if (match.Team1Id != match.Team2Id)
                        _matchRepository.UpdateMatch(match);
                    else
                        Console.WriteLine("Teams can't be same!");
                }
                else
                    Console.WriteLine("Wrong id for teams!");
            }
            else
                Console.WriteLine("Match doesn't exist!");
        }

        public void DeleteMatch()
        {
            Match match = new Match();
            Console.Write("Enter team 1 name: ");
            match.Team1 = new Team();
            match.Team1.Name = Console.ReadLine();
            Console.Write("Enter team 2 name: ");
            match.Team2 = new Team();
            match.Team2.Name = Console.ReadLine();
            Console.Write("Enter date: ");
            match.Date = DateTime.Parse(Console.ReadLine());

            match = _matchRepository.FindMatch(match);
            if (_matchRepository.IsExists(match))
            {
                Console.WriteLine("Are you sure you want to delete this match?\n" +
                                "1.Yes\n" +
                                "2.No");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    _matchRepository.DeleteMatch(match);
                }
                else
                    return;
            }
            else
                Console.WriteLine("Match doesn't exist!");
        }


        public void SelectTopBombardiersOfTeam(int top)
        {
            Team team = new Team();

            Console.WriteLine("Enter team name: ");
            team.Name = Console.ReadLine();
            Console.WriteLine("Enter team city: ");
            team.City = Console.ReadLine();

            if (_teamRepository.IsExists(team))
            {
                team = _teamRepository.FindByNameAndCity(team.Name, team.City);

                var matchesWherePlayersScored = from match in _matchRepository.GetMatches()
                                                where match.Team1 == team || match.Team2 == team
                                                select match.PlayersScored;

                var topPlayers = matchesWherePlayersScored
                    .Where(match => match != null)
                    .SelectMany(match => match)
                    .ToList()
                    .GroupBy(p => p)
                    .OrderByDescending(p => p.Count())
                    .Select(p => p.Key)
                    .Take(top);

                foreach (var player in topPlayers)
                {
                    ShowPlayer(player);
                }
            }
        }

        public void SelectTopBombardiersOfTournament(int top)
        {
            var matchesWherePlayersScored = from match in _matchRepository.GetMatches()
                                            select match.PlayersScored;

            var topPlayers = matchesWherePlayersScored
                .Where(match => match != null)
                .SelectMany(match => match)
                .ToList()
                .GroupBy(p => p)
                .OrderByDescending(p => p.Count())
                .Select(p => p.Key)
                .Take(top);

            foreach (var player in topPlayers)
            {
                ShowPlayer(player);
            }
        }
    }
}
