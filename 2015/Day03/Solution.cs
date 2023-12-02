namespace AdventOfCode.Y2015.Day03;

[ProblemName("Perfectly Spherical Houses in a Vacuum")]
internal class Solution : Solver
{
	public object PartOne(string input)
	{
		Dictionary<(int, int), int> houses = new();

		int x = 0;
		int y = 0;

		houses.Add((0, 0), 2);

		for(int i = 0; i < input.Length; i++)
		{
			char direction = input.ElementAt(i);

			if(direction == '>')
				x++;
			else if(direction == '<')
				x--;
			else if(direction == '^')
				y++;
			else if(direction == 'v')
				y--;

			if(houses.ContainsKey((x, y)))
			{
				houses[(x, y)]++;
			}
			else
			{
				houses.Add((x, y), 1);
			}
		}

		return houses.Count();
	}

	public object PartTwo(string input)
	{
		Dictionary<(int, int), int> houses = new();

		int realX = 0;
		int roboX = 0;
		int realY = 0;
		int roboY = 0;

		houses.Add((0, 0), 2);

		for(int i = 0; i < input.Length; i++)
		{
			char direction = input.ElementAt(i);
			int xChange = 0;
			int yChange = 0;

			if(direction == '>')
				xChange++;
			else if(direction == '<')
				xChange--;
			else if(direction == '^')
				yChange++;
			else if(direction == 'v')
				yChange--;

			if(i % 2 == 0)
			{
				realX += xChange;
				realY += yChange;

				if(houses.ContainsKey((realX, realY)))
				{
					houses[(realX, realY)]++;
				}
				else
				{
					houses.Add((realX, realY), 1);
				}
			}
			else
			{
				roboX += xChange;
				roboY += yChange;

				if(houses.ContainsKey((roboX, roboY)))
				{
					houses[(roboX, roboY)]++;
				}
				else
				{
					houses.Add((roboX, roboY), 1);
				}
			}
		}

		return houses.Count;
	}
}
