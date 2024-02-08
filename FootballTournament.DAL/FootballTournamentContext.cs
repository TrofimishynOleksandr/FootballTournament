using Microsoft.EntityFrameworkCore;

namespace FootballTournament.DAL
{
    public class FootballTournamentContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-R452REA\SQLEXPRESS;Initial Catalog=Football Tournament;Integrated Security=True;Connect Timeout=30;");
        }
    }
}
