using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6
{
    public class Tournament
    {
        public string TeamAName { get; }

        public string TeamBName { get; }

        public int TeamAPoints => _matchResults.Sum(matchResult => matchResult.TeamAPoints);

        public int TeamBPoints => _matchResults.Sum(matchResult => matchResult.TeamBPoints);

        private List<MatchResult> _matchResults = new List<MatchResult>();
        
        public Tournament(string teamAName, string teamBName)
        {
            TeamAName = teamAName;
            TeamBName = teamBName;
        }

        public void AddMatchResults(string[] matchResults)
        {
            if (matchResults == null) throw new InvalidMatchResultException(null);

            foreach (var matchResult in matchResults)
            {
                _matchResults.Add(new MatchResult(matchResult));
            }
        }
    }
}
