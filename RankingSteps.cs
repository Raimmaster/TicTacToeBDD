using System;
using System.Collections.Generic;
using System.Linq;
using ExamenUnoSoftware.Spec;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ExamenUnoSoftware
{
    [Binding]
    public class RankingSteps
    {
        private List<RankingPlayer> rankingTable;
        private List<Matches> matches;

        [Given(@"the follow game table")]
        public void GivenTheFollowGameTable(Table table)
        {
            matches = table.CreateSet<Matches>().ToList();
        }
        
        [Then(@"the ranking table should look like")]
        public void ThenTheRankingTableShouldLookLike(Table table)
        {
            var game = new TicTacToe(null, null);
            List<RankingPlayer> gameRanking = game.GetRankingFromList(matches); 
            rankingTable = table.CreateSet<RankingPlayer>().ToList();

            for(int i = 0; i < rankingTable.Count; ++i)
            {
                RankingPlayer playerFromTable = rankingTable[i];
                RankingPlayer playerFromList = gameRanking[i];

                Assert.AreEqual(playerFromTable.PlayerName, playerFromList.PlayerName);
            }
        }
    }
}
