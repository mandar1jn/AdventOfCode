namespace AdventOfCode.Y2015.Day01;

[ProblemName("Not Quite Lisp")]
internal class Solution : Solver
{
	public object PartOne(string input)
	{
		int floor = 0;

		for(int i = 0; i < input.Length; i++)
		{
			floor += (input[i] == '(')? 1 : -1;
		}

		return floor;
	}

	public object PartTwo(string input)
	{
		int floor = 0;

		for(int i = 0; i < input.Length; i++)
		{
			floor += (input[i] == '(')? 1 : -1;

			if(floor < 0)
				return i + 1;
		}

		return input.Length;
	}
}
