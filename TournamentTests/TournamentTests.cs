using ConsoleApp6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TournamentTests
{
    [TestClass]
    public class TournamentTests
    {
        [TestMethod]
        [DataRow(null)]
        [DataRow(new string[] { "1:g" })]
        [DataRow(new string[] { "ff", "f:f" })]
        public void AddWrongMatchResultsTest(string[] matchResults)
        {
            var tournament = new Tournament("Team1", "Team2");
            
            Assert.ThrowsException<InvalidMatchResultException>(() => tournament.AddMatchResults(matchResults));
        }

        [TestMethod]
        [DataRow(new string[] { })]
        [DataRow(new string[] { "1:5", "2:2", "3:1" })]
        public void AddMatchResultsTest(string[] matchResults)
        {
            var tournament = new Tournament("Team1", "Team2");

            tournament.AddMatchResults(matchResults);
        }
    }
}
