﻿using System;
using Moq;
using TechTalk.SpecFlow;

namespace ExamenUnoSoftware
{
    [Binding]
    public class NewGameSteps
    {

        //private Mock<IGameManager> _gameManager = new Mock<IGameManager>();
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
            //_gameManager.play(_playerOneName, _playerTwoName);
        }

        [Then(@"both players should be asked for their names")]
        public void ThenBothPlayersShouldBeAskedForTheirNames()
        {
            int playerCount = 2;
            //_gameManager.Verify(i => i.addPlayer(It.IsAny<string>()), Times.AtLeast(playerCount));
        }
    }
}
