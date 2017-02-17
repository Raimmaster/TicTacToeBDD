using System;
using System.Collections.Generic;
using Moq;

namespace ExamenUnoSoftware.Spec
{
    public class TicTacToe
    {
        private IGameManager gameManager;
        private IRandomizer _randomizer;
        private Board board;
        private IFileWriter _fileWriter;
        public Player CurrentPlayer { get; set; }

        public TicTacToe(IGameManager gameManager, IRandomizer randomizerObject)
        {
            this.gameManager = gameManager;
            this._randomizer = randomizerObject;
        }

        public TicTacToe(IGameManager gameManagerObject, IRandomizer randomizerObject, IFileWriter fileWriter)
        {
            this.gameManager = gameManagerObject;
            this._randomizer = randomizerObject;
            this._fileWriter = fileWriter;
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
            string[] symbols = {"X", "0"};
            int firstSymbolIndex = _randomizer.GetRandom(0, 2);
            int secondSymbolIndex = firstSymbolIndex == 1 ? 0 : 1;
            players[0].SetSymbol(symbols[firstSymbolIndex]);
            players[1].SetSymbol(symbols[secondSymbolIndex]);
        }

        public List<Player> GetPlayers()
        {
            return gameManager.GetPlayers();
        }

        public void setBoard(Board board)
        {
            this.board = board;
        }

        public bool isValidMove(int rowPos, int columnPos)
        {
            string posChar = board.GetCharAtPos(rowPos, columnPos);

            return posChar.Equals(" ");
        }

        public bool CheckWin()
        {
            string currentSymbol = CurrentPlayer.symbol;
            bool rowWin = board.CheckRowWin(currentSymbol);
            bool columnWin = board.CheckColumnWin(currentSymbol);
            bool diagonalWin = board.CheckDiagonalWin(currentSymbol);

            bool win = rowWin || columnWin || diagonalWin;

            if (win)
            {
                _fileWriter.WriteVictory(CurrentPlayer.name);
            }

            return win;
        }
    }
}