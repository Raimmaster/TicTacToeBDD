using System;
using System.Collections.Generic;
using ExamenUnoSoftware.Spec;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;

namespace ExamenUnoSoftware
{
    [Binding]
    public class ValidateDrawGameSteps
    {
        private Mock<IGameManager> _gameManager = new Mock<IGameManager>();
        private Mock<IFileWriter> _fileWriter = new Mock<IFileWriter>();
        private TicTacToe _game;
        private bool boardIsFull;

        [Given(@"this next full board")]
        public void GivenThisNextFullBoard(Table table)
        {
            _game = new TicTacToe(_gameManager.Object, null, _fileWriter.Object);

            var board = new Board();
            board.SetFromTable(table);
            _game.setBoard(board);
        }

        [Then(@"the match is drawed")]
        public void ThenTheMatchIsDrawed()
        {
            boardIsFull = _game.CheckBoardIsFull();
            Assert.IsTrue(boardIsFull);
        }
        
        [Then(@"nothing should be written")]
        public void ThenNothingShouldBeWritten()
        {
            _fileWriter.Verify(x => x.WriteVictory(It.IsAny<String>()), Times.Never);
        }
    }
}
