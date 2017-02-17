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

        public void setPlayers(string playerOneName, string playerTwoName)
        {
            if(!string.IsNullOrEmpty(playerOneName))
                gameManager.AddPlayer(playerOneName);

            if(!string.IsNullOrEmpty(playerTwoName))
                gameManager.AddPlayer(playerTwoName);
        }

        public void setInitialPlayer()
        {
            CurrentPlayer = gameManager.GetPlayers()[_randomizer.GetRandom(0, 2)];
        }
    }
}