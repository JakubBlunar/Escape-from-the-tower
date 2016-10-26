using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotSemestralkaJakubBlunar
{
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }


        public int H { get; set; }
        public int M { get; set; }
        public int S { get; set; }
        public string NameOfPlayer { get; set; }
        public string Date { get; set; }
        public string NameOfPc { get; set; }

        

        public Score(string name, TimeSpan elapsed, DateTime date)
        {
            H = elapsed.Hours;
            M = elapsed.Minutes;
            S = elapsed.Seconds;
            NameOfPlayer = name;
            Date = date.ToString();
            NameOfPc = Environment.MachineName;
        }
    }
    

}
