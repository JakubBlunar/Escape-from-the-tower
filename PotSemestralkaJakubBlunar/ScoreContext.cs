using System.Data.Entity;

namespace PotSemestralkaJakubBlunar
{
    /// <summary>
    ///     Db context for scores
    /// </summary>
    public class ScoreContext : DbContext
    {
        public ScoreContext() : base("highscore")
        {
        }

        public DbSet<Score> Scores { get; set; }
    }
}