using ConsoleApp6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TournamentTests
{
    [TestClass]
    public class MatchResultTests
    {
        [TestMethod]
        [DataRow(-1, -1)]
        [DataRow(-1, 0)]
        [DataRow(0, -1)]
        [DataRow(int.MinValue, 5)]
        public void MatchResultConstructorWrongArgumentsTest(int teamAScore, int teamBScore)
        {
            Assert.ThrowsException<InvalidMatchResultException>(() => new MatchResult(teamAScore, teamBScore), "Неверные данные прошли валидацию при создании MatchResult.");
        }

        [TestMethod]
        [DataRow(5, 5, 1, 1)]
        [DataRow(0, 0, 1, 1)]
        [DataRow(5, 0, 3, 0)]
        [DataRow(0, 3, 0, 3)]
        public void MatchResultTest(int teamAScore, int teamBScore, int expectedTeamAPoints, int expectedTeamBPoints)
        {
            var matchResult = new MatchResult(teamAScore, teamBScore);

            Assert.AreEqual(matchResult.TeamAPoints, expectedTeamAPoints, "Неверное количество очков матча для команды A.");
            Assert.AreEqual(matchResult.TeamBPoints, expectedTeamBPoints, "Неверное количество очков матча для команды B.");
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("abc:def")]
        [DataRow("1:f")]
        [DataRow(":")]
        [DataRow("1 1")]
        [DataRow("11")]
        [DataRow("1")]
        [DataRow("1:")]
        [DataRow(":1")]
        public void MatchResultConstructorWrongArgumentsTest(string matchResult)
        {
            Assert.ThrowsException<InvalidMatchResultException>(() => new MatchResult(matchResult), "Неверные данные прошли валидацию при создании MatchResult.");
        }

        [TestMethod]
        [DataRow("1:1", 1, 1)]
        [DataRow("0:0", 1, 1)]
        [DataRow("2:1", 3, 0)]
        [DataRow("0:5", 0, 3)]
        public void MatchResultTest(string matchResultString, int expectedTeamAPoints, int expectedTeamBPoints)
        {
            var matchResult = new MatchResult(matchResultString);

            Assert.AreEqual(matchResult.TeamAPoints, expectedTeamAPoints, "Неверное количество очков матча для команды A.");
            Assert.AreEqual(matchResult.TeamBPoints, expectedTeamBPoints, "Неверное количество очков матча для команды B.");
        }
    }
}