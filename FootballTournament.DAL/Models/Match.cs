using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTournament.DAL.Models
{
    public class Match
    {
        public int Id { get; set; }

        public int Team1Id { get; set; }

        public virtual Team Team1 { get; set; }

        public int Team2Id { get; set; }

        public virtual Team Team2 { get; set; }

        public int Team1Score { get; set; }

        public int Team2Score { get; set; }

        public List<Player> PlayersScored { get; set; }

        public DateTime Date { get; set; }
    }
}
