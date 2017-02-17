using System;
using Moq;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamenUnoSoftware.Spec
{
    [Binding]
    public class NewGameSteps
    {

        private Mock<IGameManager> _gameManager = new Mock<IGameManager>();
        private TicTacToe game;
        private string _playerOneName;
        private string _playerTwoName;

        [Given(@"'(.*)' and '(.*)'")]
        public void GivenAnd(string p0, string p1)
        {
            _playerOneName = p0;
            _playerTwoName = p1;
        }

        [When(@"I start the match")]
        public void WhenIStartTheMatch()
        {
            game = new TicTacToe(_gameManager.Object, null);
            _gameManager.Setup(x => x.AddPlayer(It.IsAny<string>()));
            game.SetPlayers(_playerOneName, _playerTwoName);
        }

        [Then(@"both players should be asked for their names")]
        public void ThenBothPlayersShouldBeAskedForTheirNames()
        {
            int playerCount = 2;
            _gameManager.Verify(i => i.AddPlayer(It.IsAny<string>()), Times.AtLeast(playerCount));
        }
    }
}
