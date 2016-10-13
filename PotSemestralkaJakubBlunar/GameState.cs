using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotSemestralkaJakubBlunar
{
    public abstract class GameState
    {

        public Game Game { get; private set; }
        public string Name { get; private set; }

        protected char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

        public GameState(string name, Game game)
        {
            Name = name;
            Game = game;
        }

        public abstract void tick();
    }
}
