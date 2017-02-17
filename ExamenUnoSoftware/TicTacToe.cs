using Moq;

namespace ExamenUnoSoftware.Spec
{
    public class TicTacToe
    {
        private IGameManager gameManager;

        public TicTacToe(IGameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public void init(string playerOneName, string playerTwoName)
        {
            if(!string.IsNullOrEmpty(playerOneName))
                gameManager.AddPlayer(playerOneName);

            if(!string.IsNullOrEmpty(playerTwoName))
                gameManager.AddPlayer(playerTwoName);
        }
    }
}