using System;
using System.Collections.Generic;
using ExamenUnoSoftware.Spec;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;

namespace ExamenUnoSoftware
{
    [Binding]
    public class ChoosePlayerOneSteps
    {
        private Mock<IGameManager> _gameManager  = new Mock<IGameManager>();
        private Mock<IRandomizer> _randomizer = new Mock<IRandomizer>();
        private TicTacToe _game;

        [Given(@"'(.*)' and '(.*)' are player one and two")]
        public void GivenAndArePlayerOneAndTwo(string p0, string p1)
        {
            _game = new TicTacToe(_gameManager.Object, _randomizer.Object);
            _gameManager.Setup(x => x.AddPlayer(It.IsAny<string>()));
            var players = new List<Player>();
            players.Add(new Player { name = p0 });
            players.Add(new Player { name = p1 });
            _gameManager.Setup(x => x.GetPlayers()).Returns(players);
            _game.SetPlayers(p0, p1);
            _randomizer.Setup(x => x.GetRandom(0, 2)).Returns(It.IsInRange(0, 1, Range.Inclusive));
            _game.SetInitialPlayer();
        }
        
        [Then(@"one will be chosen randomly to be player one")]
        public void ThenOneWillBeChosenRandomlyToBePlayerOne()
        {
            _randomizer.Verify(x => x.GetRandom(0, 2), Times.Once);
            Assert.IsNotNull(_game.CurrentPlayer);
        }
    }
}
