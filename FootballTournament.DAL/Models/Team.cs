﻿namespace FootballTournament.DAL.Models
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

        public List<Player> Players { get; set; }

        public List<Match>? Matches { get; set; }
    }
}
