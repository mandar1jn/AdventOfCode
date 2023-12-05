using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.Day04;

[ProblemName("Scratchcards")]
class Solution : Solver
{

	public object PartOne(string input) =>
	(
		from line in input.Split(Environment.NewLine)
		let intersects = GetMatches(line)
		where intersects > 0
		select Math.Pow(2, intersects - 1)
	).Sum();

	public object PartTwo(string input)
	{
		var cards = input.Split("\n").Select(GetMatches).ToArray();
        var counts = cards.Select(_ => 1).ToArray();

        for (var i = 0; i < cards.Length; i++) {
            var (card, count) = (cards[i], counts[i]);
            for (var j = 0; j < card; j++) {
                counts[i + j + 1] += count;
            }
        }
        return counts.Sum();
	}

	private static int GetMatches(string card)
	{
		var parts = card.Split(':', '|');
		var wins = from win in Regex.Matches(parts[1], @"(\d+)") select win.Value;
		var realNums = from real in Regex.Matches(parts[2], @"(\d+)") select real.Value;
		return wins.Intersect(realNums).Count();
	}

}
				