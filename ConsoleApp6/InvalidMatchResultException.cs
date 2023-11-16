using System;

namespace ConsoleApp6
{
    public class InvalidMatchResultException : Exception
    {
        public string MatchResult { get; }

        public override string Message => $"Неверный формат результата матча [{MatchResult}]. Формат должен быть - D:D, где D - число больше или равное нулю.";

        public InvalidMatchResultException(string matchResult)
        {
            MatchResult = matchResult;
        }
    }
}
