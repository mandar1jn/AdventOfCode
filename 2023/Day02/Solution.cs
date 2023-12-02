using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.Day02;

[ProblemName("Cube Conundrum")]
internal class Solution : Solver
{
	public object PartOne(string input)=>
	(
		from line in input.Split(Environment.NewLine)
		let game = ParseGame(line)
		where game.red <= 12 && game.green <= 13 && game.blue <= 14
		select game.id
	).Sum();

	public object PartTwo(string input) =>
	(
		from line in input.Split(Environment.NewLine)
		let game = ParseGame(line)
		select game.red * game.green * game.blue
	).Sum();

	private static Game ParseGame(string input) => new()
	{
		id = GetInts(input, @"Game (\d+)").First(),
		red = GetInts(input, @"(\d+) red").Max(),
		green = GetInts(input, @"(\d+) green").Max(),
		blue = GetInts(input, @"(\d+) blue").Max(),
	};

	private static IEnumerable<int> GetInts(string input, string regex) => 
	(
		from match in Regex.Matches(input, regex)
		select int.Parse(match.Groups[1].Value)
	);
}

struct Game {
	public int id;
	public int red;
	public int green;
	public int blue;
}
