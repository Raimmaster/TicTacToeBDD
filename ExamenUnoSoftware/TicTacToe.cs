using System;
using System.Collections.Generic;
using Moq;

namespace ExamenUnoSoftware.Spec
{
    public class TicTacToe
    {
        private IGameManager gameManager;
        private IRandomizer _randomizer;
        public Player CurrentPlayer { get; set; }

        public TicTacToe(IGameManager gameManager, IRandomizer randomizerObject)
        {
            this.gameManager = gameManager;
            this._randomizer = randomizerObject;
        }

        public void SetPlayers(string playerOneName, string playerTwoName)
        {
            if(!string.IsNullOrEmpty(playerOneName))
                gameManager.AddPlayer(playerOneName);

            if(!string.IsNullOrEmpty(playerTwoName))
                gameManager.AddPlayer(playerTwoName);
        }

        public void SetInitialPlayer()
        {
            CurrentPlayer = gameManager.GetPlayers()[_randomizer.GetRandom(0, 2)];
        }

        public void SetSymbolsForEachPlayer()
        {
            var players = gameManager.GetPlayers();
            char[] symbols = {'X', '0'};
            int firstSymbolIndex = _randomizer.GetRandom(0, 2);
            int secondSymbolIndex = firstSymbolIndex == 1 ? 0 : 1;
            players[0].SetSymbol(symbols[firstSymbolIndex]);
            players[1].SetSymbol(symbols[secondSymbolIndex]);
        }

        public List<Player> GetPlayers()
        {
            return gameManager.GetPlayers();
        }
    }
}