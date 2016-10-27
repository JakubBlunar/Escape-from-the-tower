using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PotSemestralkaJakubBlunar
{
    /// <summary>
    ///     Poco object from db, for saving player score
    /// </summary>
    public class Score
    {
        public Score()
        {
        }

        public Score(string name, TimeSpan elapsed, DateTime date, int money)
        {
            H = elapsed.Hours;
            M = elapsed.Minutes;
            S = elapsed.Seconds;
            NameOfPlayer = name;
            Date = date.ToString(CultureInfo.CurrentCulture);
            MoneyCollected = money;
            NameOfPc = Environment.MachineName;
        }

        [Key]
        public int ScoreId { get; set; }

        public int H { get; set; }
        public int M { get; set; }
        public int S { get; set; }
        public string NameOfPlayer { get; set; }
        public string Date { get; set; }
        public string NameOfPc { get; set; }
        public int MoneyCollected { get; set; }
    }
}