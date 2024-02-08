
namespace FootballTournament.DAL
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public int VictoriesAmount { get; set; }

        public int LossesAmount { get; set; }

        public int DrawsAmount { get; set; }

        public int ScoredGoalsAmount { get; set; }

        public int ConcededGoalsAmount { get; set; }
    }
}
