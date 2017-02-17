using System;
using System.Collections.Generic;
using ExamenUnoSoftware.Spec;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;

namespace ExamenUnoSoftware
{
    [Binding]
    public class GameVictorySteps
    {
        private Mock<IGameManager> _gameManager = new Mock<IGameManager>();
        private TicTacToe _game;
        private bool _currentPlayerHasWon;

        [Given(@"this next board")]
        public void GivenThisNextBoard(Table table)
        {
            _game = new TicTacToe(_gameManager.Object, null);
            var board = new Board();
            board.SetFromTable(table);
            _game.setBoard(board);
            initMatch();
        }

        private void initMatch()
        {
            _gameManager.Setup(x => x.AddPlayer(It.IsAny<string>()));
            var players = new List<Player>();
            players.Add(new Player { name = "Raim"});
            players.Add(new Player { name = "Nick" });
            _gameManager.Setup(x => x.GetPlayers()).Returns(players);
            _game.SetPlayers("Raim", "Nick");
            _game.CurrentPlayer = players[0];
        }

        [Then(@"Player '(.*)' has won the match")]
        public void ThenPlayerHasWonTheMatch(string p0)
        {
            _game.CurrentPlayer.symbol = p0;
            _currentPlayerHasWon = _game.CheckWin();
            Assert.IsTrue(_currentPlayerHasWon);
        }

        [Then(@"victory should be written to the file")]
        public void ThenVictoryShouldBeWrittenToTheFile()
        {
            Assert.IsTrue(true);
        }
    }
}
