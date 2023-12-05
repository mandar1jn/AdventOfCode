using System.Runtime.ExceptionServices;

namespace AdventOfCode.Y2016.Day01;

enum Direction
{
	NORTH,
	EAST,
	SOUTH,
	WEST
}

[ProblemName("No Time for a Taxicab")]
class Solution : Solver
{

	public object PartOne(string input)
	{
		var directions = input.Split(", ");

		int xBlocks = 0;
		int yBlocks = 0;

		Direction dir = Direction.NORTH;

		for (int i = 0; i < directions.Length; i++)
		{
			var direction = directions[i];

			var turn = direction[0];
			var count = int.Parse(direction[1..]);

			if (turn == 'R')
			{
				switch (dir)
				{
					case Direction.NORTH:
						dir = Direction.EAST;
						break;
					case Direction.EAST:
						dir = Direction.SOUTH;
						break;
					case Direction.SOUTH:
						dir = Direction.WEST;
						break;
					case Direction.WEST:
						dir = Direction.NORTH;
						break;
				}
			}
			else if (turn == 'L')
			{
				switch (dir)
				{
					case Direction.NORTH:
						dir = Direction.WEST;
						break;
					case Direction.EAST:
						dir = Direction.NORTH;
						break;
					case Direction.SOUTH:
						dir = Direction.EAST;
						break;
					case Direction.WEST:
						dir = Direction.SOUTH;
						break;
				}
			}

			switch (dir)
			{
				case Direction.NORTH:
					yBlocks += count;
					break;
				case Direction.EAST:
					xBlocks += count;
					break;
				case Direction.SOUTH:
					yBlocks -= count;
					break;
				case Direction.WEST:
					xBlocks -= count;
					break;
			}
		}

		return Math.Abs(xBlocks) + Math.Abs(yBlocks);
	}

	public object PartTwo(string input)
	{
		var directions = input.Split(", ");

		int xBlocks = 0;
		int yBlocks = 0;

		List<(int, int)> positions = new()
		{
			(0, 0)
		};

		Direction dir = Direction.NORTH;

		for (int i = 0; i < directions.Length; i++)
		{
			var direction = directions[i];

			var turn = direction[0];
			var count = int.Parse(direction[1..]);

			if (turn == 'R')
			{
				switch (dir)
				{
					case Direction.NORTH:
						dir = Direction.EAST;
						break;
					case Direction.EAST:
						dir = Direction.SOUTH;
						break;
					case Direction.SOUTH:
						dir = Direction.WEST;
						break;
					case Direction.WEST:
						dir = Direction.NORTH;
						break;
				}
			}
			else if (turn == 'L')
			{
				switch (dir)
				{
					case Direction.NORTH:
						dir = Direction.WEST;
						break;
					case Direction.EAST:
						dir = Direction.NORTH;
						break;
					case Direction.SOUTH:
						dir = Direction.EAST;
						break;
					case Direction.WEST:
						dir = Direction.SOUTH;
						break;
				}
			}

			for(int _ = 0; _ < count; _++)
			{
				switch (dir)
				{
					case Direction.NORTH:
						yBlocks++;
						break;
					case Direction.EAST:
						xBlocks++;
						break;
					case Direction.SOUTH:
						yBlocks--;
						break;
					case Direction.WEST:
						xBlocks--;
						break;
				}

				if(positions.Contains((xBlocks, yBlocks)))
				{
					return Math.Abs(xBlocks) + Math.Abs(yBlocks);
				}

				positions.Add((xBlocks, yBlocks));
			}

		}

		return -1;
	}

}
