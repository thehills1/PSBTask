using System;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tournament = new Tournament("Команда 1", "Команда 2");
            var matchResults = new string[] { "3:1", "2:2", "0:1", "4:2" };
            tournament.AddMatchResults(matchResults);
            Console.WriteLine($"{tournament.TeamAName}: {tournament.TeamAPoints}\n{tournament.TeamBName}: {tournament.TeamBPoints}");
        }
    }
}