using System.Collections.Generic;

namespace PotSemestralkaJakubBlunar
{
    /// <summary>
    /// Class that manages game state.
    /// </summary>
    public class StateManager
    {
        private Dictionary<string, GameState> GameStates { get; set; }
        public GameState Actual { get; set; }

        /// <summary>
        /// Creates new manager with new actual state.
        /// </summary>
        /// <param name="first">First state of the game</param>
        public StateManager(GameState first)
        {
            GameStates = new Dictionary<string, GameState>();
            Actual = first;
            GameStates.Add(first.Name, first);
        }

        /// <summary>
        /// Starts loop of actal state.
        /// </summary>
        public void Tick()
        {
            Actual.Tick();
        }

        /// <summary>
        /// Change actual state to some new.
        /// </summary>
        /// <param name="paNew">Name of new state.</param>
        public void ChangeState(string paNew)
        {
            if (!GameStates.ContainsKey(paNew)) return;
            Actual = GameStates[paNew];
        }

        /// <summary>
        /// Add new state.
        /// </summary>
        /// <param name="state">New state to add.</param>
        public void AddState(GameState state)
        {
            if (GameStates.ContainsKey(state.Name)) return;
            GameStates.Add(state.Name, state);
        }

        /// <summary>
        /// Returns state with specified name.
        /// </summary>
        /// <param name="v">Name of state.</param>
        /// <returns>Game state with specified name.</returns>
        public GameState GetGameState(string v)
        {
            if(GameStates.ContainsKey(v)) return GameStates[v];
            return null;
            
        }
    }
}
