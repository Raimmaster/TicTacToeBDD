using System;
using TechTalk.SpecFlow;

namespace ExamenUnoSoftware
{
    [Binding]
    public class ChoosePlayerSymbols
    {
        [Given(@"'(.*)' and '(.*)' are both players")]
        public void GivenAndAreBothPlayers(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"one will be chosen randomly to use symbol X or (.*)")]
        public void ThenOneWillBeChosenRandomlyToUseSymbolXOr(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
