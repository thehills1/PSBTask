using System.Text.RegularExpressions;

namespace ConsoleApp6
{
    public class MatchResult
    {
        private const string MatchResultPattern = @"^(\d{1,})\:(\d{1,})$";

        public int TeamAScore { get; private set; }

        public int TeamBScore { get; private set; }

        public int TeamAPoints => GetTeamPoints(TeamAScore, TeamBScore);

        public int TeamBPoints => GetTeamPoints(TeamBScore, TeamAScore);

        public MatchResult(int teamAScore, int teamBScore)
        {
            if (teamAScore < 0 || teamBScore < 0) throw new InvalidMatchResultException($"{teamAScore}:{teamBScore}");

            TeamAScore = teamAScore;
            TeamBScore = teamBScore;
        }

        public MatchResult(string matchResult)
        {
            var match = Regex.Match(matchResult, MatchResultPattern);
            if (!match.Success) throw new InvalidMatchResultException(matchResult);

            var teamAScore = int.Parse(match.Groups[1].Value);
            var teamBScore = int.Parse(match.Groups[2].Value);

            if (teamAScore < 0 || teamBScore < 0) throw new InvalidMatchResultException(matchResult);

            TeamAScore = teamAScore;
            TeamBScore = teamBScore;
        }

        private int GetTeamPoints(int currentTeamScore, int otherTeamScore)
        {
            if (currentTeamScore == otherTeamScore) return 1;

            if (currentTeamScore > otherTeamScore) return 3;

            return 0;
        }
    }
}
