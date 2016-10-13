using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotSemestralkaJakubBlunar
{
    public class StateManager
    {
        private Dictionary<string, GameState> GameStates { get; set; }
        public GameState Actual { get; set; }

        public StateManager(GameState first)
        {
            GameStates = new Dictionary<string, GameState>();
            Actual = first;
            GameStates.Add(first.Name, first);
        }

        public void tick()
        {
            Actual.tick();
        }

        public void ChangeState(string paNew)
        {
            if (!GameStates.ContainsKey(paNew)) return;
            Actual = GameStates[paNew];
        }

        public void AddState(GameState state)
        {
            if (GameStates.ContainsKey(state.Name)) return;
            GameStates.Add(state.Name, state);
        }

        public GameState GetGameState(string v)
        {
            if(GameStates.ContainsKey(v)) return GameStates[v];
            return null;
            
        }
    }
}
