﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTournament.DAL.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Country { get; set; }

        public int Number { get; set; }

        public string Position { get; set; }

        public List<Match> Matches { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }
    }
}
