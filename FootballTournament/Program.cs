using FootballTournament.DAL;

namespace FootballTournament
{
    internal class Program
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

                foreach (var team in context.Teams)
                {
                    Console.WriteLine($"{team.Name}, {team.City}, {team.VictoriesAmount}, {team.LossesAmount}, {team.DrawsAmount}");
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
