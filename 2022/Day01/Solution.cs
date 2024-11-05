namespace AdventOfCode.Y2022.Day01;

[ProblemName("Calorie Counting")]
class Solution : Solver
{

	public object PartOne(string input)
	{
		string[] lines = input.Split('\n');

		int current = 0;
		int max = 0;

		for (int i = 0; i < lines.Length; i++)
		{
			string line = lines[i].Trim();
			if (line == "")
			{
				if (current > max)
				{
					max = current;
				}
				current = 0;
				continue;
			}

			current += int.Parse(line);
		}

		return max;
	}

	public object PartTwo(string input)
	{
		string[] lines = input.Split('\n');

		int[] highest = new int[3];

		int current = 0;

		for (int i = 0; i < lines.Length; i++)
		{
			string line = lines[i].Trim();
			if (line == "")
			{
				if (current > highest[0])
				{
					highest[0] = current;
					Array.Sort(highest);
				}
				current = 0;
				continue;
			}

			current += int.Parse(line);
		}

		return highest[0] + highest[1] + highest[2];
	}

}
