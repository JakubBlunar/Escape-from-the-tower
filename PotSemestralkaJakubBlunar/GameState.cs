﻿namespace PotSemestralkaJakubBlunar
{
    /// <summary>
    /// Class GameState represents base class for state of game, which has own commands and display different informations.
    /// There is atributes that are common for all specified states.
    /// Main menu, playing game, looking into some object
    /// </summary>
    public abstract class GameState
    {

        public Game Game { get; private set; }

        /// <summary>
        /// Name of specified state
        /// </summary>
        public string Name { get; private set; }

        protected char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

        /// <summary>
        /// Creates new base class for game state
        /// </summary>
        /// <param name="name">Name of gamestate</param>
        /// <param name="game">Instance of game</param>
        public GameState(string name, Game game)
        {
            Name = name;
            Game = game;
        }

        /// <summary>
        /// Base method for each state. There is main loop of state.
        /// </summary>
        public abstract void Tick();
    }
}
