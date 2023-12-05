namespace AdventOfCode.Y2016.Day02;

[ProblemName("Bathroom Security")]
class Solution : Solver
{

	readonly int[,] keypad1 = {
		{1, 2, 3},
		{4, 5, 6},
		{7, 8, 9}
	};

	readonly string[,] keypad2 = {
		{"", "", "1", "", ""},
		{"", "2", "3", "4", ""},
		{"5", "6", "7", "8", "9"},
		{"", "A", "B", "C", ""},
		{"", "", "D", "", ""},
	};

	public object PartOne(string input)
	{
		int x = 1;
		int y = 1;

		var lines = input.Split(Environment.NewLine);

		int code = 0;

		for(int i = 0; i < lines.Length; i++)
		{
			var line = lines[i];

			for(int j = 0; j < line.Length; j++)
			{
				var character = line.ElementAt(j);

				switch(character)
				{
					case 'U':
						y--;
						break;
					case 'D':
						y++;
						break;
					case 'L':
						x--;
						break;
					case 'R':
						x++;
						break;
				}

				x = Math.Clamp(x, 0, 2);
				y = Math.Clamp(y, 0, 2);

			}

			code *= 10;

			code += keypad1[y, x];
		}

		return code;
	}

	public object PartTwo(string input)
	{
		int x = 2;
		int y = 0;

		var lines = input.Split(Environment.NewLine);

		string code = "";

		for(int i = 0; i < lines.Length; i++)
		{
			var line = lines[i];

			for(int j = 0; j < line.Length; j++)
			{
				var character = line.ElementAt(j);

				var (oldX, oldY) = (x, y);

				switch(character)
				{
					case 'U':
						y--;
						break;
					case 'D':
						y++;
						break;
					case 'L':
						x--;
						break;
					case 'R':
						x++;
						break;
				}

				x = Math.Clamp(x, 0, 4);
				y = Math.Clamp(y, 0, 4);

				if(keypad2[y, x] == "")
				{
					(x, y) = (oldX, oldY);
				}
			}

			code += keypad2[y, x];
		}

		return code;
	}

}
				