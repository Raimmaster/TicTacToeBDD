using System;
using ExamenUnoSoftware.Spec;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;

namespace ExamenUnoSoftware
{
    [Binding]
    public class EmptySlotSteps
    {
        private Mock<IGameManager> _gameManager = new Mock<IGameManager>();
        private TicTacToe _game;
        private int _rowPos;
        private int _columnPos;

        [Given(@"the next board")]
        public void GivenTheNextBoard(Table table)
        {
            _game = new TicTacToe(_gameManager.Object, null);
            Board board = new Board();
            board.SetFromTable(table);
            _game.setBoard(board);
        }

        [When(@"a players picks row (.*) and column (.*)")]
        public void WhenAPlayersPicksRowAndColumn(int p0, int p1)
        {
            _rowPos = p0;
            _columnPos = p1;
        }
        
        [Then(@"it should be a valid move")]
        public void ThenItShouldBeAValidMove()
        {
            bool isValidPosition = _game.isValidMove(_rowPos, _columnPos);
            Assert.IsTrue(isValidPosition);
        }
        
        [Then(@"other player picks row (.*) and columns (.*)")]
        public void ThenOtherPlayerPicksRowAndColumns(int p0, int p1)
        {
            _rowPos = p0;
            _columnPos = p1;
        }
        
        [Then(@"it should be an invalid move")]
        public void ThenItShouldBeAnInvalidMove()
        {
            var isValidPosition = _game.isValidMove(_rowPos, _columnPos);
            Assert.IsFalse(isValidPosition);
        }
    }
}
