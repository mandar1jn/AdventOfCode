using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.Day01
{
	[ProblemName("Trebuchet?!")]
	internal class Solution : Solver
	{
		public object PartOne(string input) => CalculateTotal(input, @"\d");

		public object PartTwo(string input) => CalculateTotal(input, @"\d|one|two|three|four|five|six|seven|eight|nine");

		static int CalculateTotal(string input, string regex) =>
			(
				from line in input.Split(Environment.NewLine)
				let first = Regex.Match(line, regex)
				let last = Regex.Match(line, regex, RegexOptions.RightToLeft)
				select GetNumber(first.Value) * 10 + GetNumber(last.Value)
			).Sum();

		static int GetNumber(string number) =>
			number switch {
				"one" => 1,
				"two" => 2,
				"three" => 3,
				"four" => 4,
				"five" => 5,
				"six" => 6,
				"seven" => 7,
				"eight" => 8,
				"nine" => 9,
				_ => int.Parse(number)
			};
	}
}
