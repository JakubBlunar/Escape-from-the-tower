using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotSemestralkaJakubBlunar
{
    public class ScoreContext: DbContext
    {

        public DbSet<Score> Scores { get; set; }

        public ScoreContext():base("highscore")
        {
            
        }
        
    }
}
