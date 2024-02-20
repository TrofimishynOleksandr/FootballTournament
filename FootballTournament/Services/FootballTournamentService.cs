using FootballTournament.DAL;
using FootballTournament.DAL.Models;
using FootballTournament.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTournament.Services
{
    public class FootballTournamentService
    {
        private TeamsProvider _teamsProvider;
        private MatchesProvider _matchesProvider;

        public FootballTournamentService(FootballTournamentContext context)
        {
            _teamsProvider = new TeamsProvider(context);
            _matchesProvider = new MatchesProvider(context);
        }

        public void FillDb()
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

        public void ShowTeams() => _teamsProvider.ShowTeams();

        public void FindByName() => _teamsProvider.FindByName();

        public void FindByCity() => _teamsProvider.FindByCity();

        public void FindByNameAndCity() => _teamsProvider.FindByNameAndCity();

        public void ShowTeamWithMaxVictories() => _teamsProvider.ShowTeamWithMaxVictories();

        public void ShowTeamWithMaxLosses() => _teamsProvider.ShowTeamWithMaxLosses();

        public void ShowTeamWithMaxDraws() => _teamsProvider.ShowTeamWithMaxDraws();

        public void ShowTeamWithMaxScored() => _teamsProvider.ShowTeamWithMaxScored();

        public void ShowTeamWithMaxConceded() => _teamsProvider.ShowTeamWithMaxConceded();

        public void AddTeam() => _teamsProvider.AddTeam();

        public void UpdateTeam() => _teamsProvider.UpdateTeam();

        public void DeleteTeam() => _teamsProvider.DeleteTeam();

        public void GoalsDifference() => _teamsProvider.GoalsDifference();


        public void ShowMatches() => _matchesProvider.ShowMatches();

        public void ShowMatch() => _matchesProvider.ShowMatch();

        public void ShowMatchWithDate() => _matchesProvider.ShowMatchWithDate();

        public void ShowMatchesOfTeam() => _matchesProvider.ShowMatchesOfTeam();

        public void ShowPlayersScoredInDate() => _matchesProvider.ShowPlayersScoredInDate();

        public void AddMatch() => _matchesProvider.AddMatch();

        public void UpdateMatch() => _matchesProvider.UpdateMatch();

        public void DeleteMatch() => _matchesProvider.DeleteMatch();

        public void SelectTopBombardiersOfTeam(int top) => _matchesProvider.SelectTopBombardiersOfTeam(top);

        public void SelectTopBombardiersOfTournament(int top) => _matchesProvider.SelectTopBombardiersOfTournament(top);
        
        public void SelectTeamsWithMaxScored(int top) => _teamsProvider.SelectTeamsWithMaxScored(top);

        public void SelectTeamsWithMinConceded(int top) => _teamsProvider.SelectTeamsWithMinConceded(top);

        public void SelectTeamsWithMaxPoints(int top) => _teamsProvider.SelectTeamsWithMaxPoints(top);

        public void SelectTeamsWithMinPoints(int top) => _teamsProvider.SelectTeamsWithMinPoints(top);
    }
}
