using System.Text.RegularExpressions;

namespace AdventOfCode.Y2016.Day03;

[ProblemName("Squares With Three Sides")]
class Solution : Solver
{

	public object PartOne(string input)
	{
		var lines = input.Split(Environment.NewLine);

		int total = 0;

		for(int i = 0; i < lines.Length; i++)
		{
			var line = lines[i];
			
			var matches = Regex.Matches(line, @"(\d+)");

			var numbers = (from num in matches select int.Parse(num.Value)).OrderBy(x => x).ToArray();

			if(numbers[0] + numbers[1] > numbers[2])
				total++;
		}

		return total;
	}

	public object PartTwo(string input)
	{
		string[,] inputs = {{}, {}, {}};

		return 0;
	}

}
				