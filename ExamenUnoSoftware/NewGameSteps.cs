using System;
using TechTalk.SpecFlow;

namespace ExamenUnoSoftware
{
    [Binding]
    public class NewGameSteps
    {
        [When(@"I start the match")]
        public void WhenIStartTheMatch()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"both players should be asked for their names")]
        public void ThenBothPlayersShouldBeAskedForTheirNames()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
