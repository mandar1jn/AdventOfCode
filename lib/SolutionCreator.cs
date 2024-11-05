using System.Net;

namespace AdventOfCode;

class SolutionCreator
{

	private static string GenerateFileText(int year, int day)
	{
		return $@"namespace AdventOfCode.Y{year}.Day{day.ToString().PadLeft(2, '0')};
				|
				|class Solution : Solver
				|{{
				|
				|	public object PartOne(string input)
				|	{{
				|		return 0;
				|	}}
				|
				|	public object PartTwo(string input)
				|	{{
				|		return 0;
				|	}}
				|
				|}}
				".StripMargins();
	}

	public static void Create(int year, int day)
	{
		string directory = Path.Combine(Environment.CurrentDirectory, year.ToString(), $"Day{day.ToString().PadLeft(2, '0')}");

		if (Directory.Exists(directory))
		{
			Console.WriteLine("A solution for this problem already exists");
			return;
		}

		Directory.CreateDirectory(directory);

		var cookieContainer = new CookieContainer();
		cookieContainer.Add(new Cookie("session", "SESSION_TOKEN", "/", "adventofcode.com"));
		using var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
		using var client = new HttpClient(handler);
		using var response = client.Send(new HttpRequestMessage(HttpMethod.Get, $"https://adventofcode.com/{year}/day/{day}/input"));
		using Stream inputStream = response.Content.ReadAsStream();
		using StreamReader reader = new StreamReader(inputStream);
		string input = reader.ReadToEnd().Trim();

		var inputFile = File.CreateText(Path.Combine(directory, "input.txt"));
		inputFile.Write(input);
		inputFile.Close();

		var solutionFile = File.CreateText(Path.Combine(directory, "Solution.cs"));
		solutionFile.Write(GenerateFileText(year, day));
		solutionFile.Close();
	}

}
