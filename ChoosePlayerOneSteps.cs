using System;
using Moq;
using TechTalk.SpecFlow;

namespace ExamenUnoSoftware
{
    [Binding]
    public class ChoosePlayerOneSteps
    {
        //private Mock<IGameManager> _gameManager  = new Mock<IGameManager>();
        //private List<Product> productsWithQtyLessThan = new List<Product>();


        [Given(@"'(.*)' and '(.*)' are player one and two")]
        public void GivenAndArePlayerOneAndTwo(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"one will be chosen randomly to be player one")]
        public void ThenOneWillBeChosenRandomlyToBePlayerOne()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
