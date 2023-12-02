using System.CommandLine;
using System.Diagnostics;
using System.Reflection;

namespace AdventOfCode
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
		{
			Type[] solverTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsClass && typeof(Solver).IsAssignableFrom(type)).ToArray();

			var rootCommand = new RootCommand("Sample app for System.CommandLine");

			rootCommand.SetHandler(() => 
				{ 
					Console.WriteLine("YEAR NUMBER");
				});

			var yearArgument = new Argument<int>(name: "year", "The year of the problem");
			var dayArgument = new Argument<int>(name: "day", "The day of the problem");

			var solutionCommand = new Command("solve");
			solutionCommand.AddArgument(yearArgument);
			solutionCommand.AddArgument(dayArgument);

			solutionCommand.SetHandler((year, day) => {
				var solvers = solverTypes.Where(type => {

					string[] namespaces = type.Namespace!.Split(".");
					string yearString = namespaces[1];
					string dayString = namespaces[2];

					int problemYear = int.Parse(yearString[1..]);
					int problemDay = int.Parse(dayString[3..]);

					return problemYear == year && problemDay == day;
				});

				if(!solvers.Any())
				{
					Console.WriteLine($"No solver found for {year}/{day}");
					return;
				}


				if (Activator.CreateInstance(solvers.First()) is not Solver solver)
				{
					Console.WriteLine("Something went wrong while creating a solver");
					return;
				}

				ProblemNameAttribute? problemName = solver.GetType().GetCustomAttribute<ProblemNameAttribute>();

				if(problemName == null)
				{
					Console.WriteLine("Could not resolve problem name. Forgot to add the ProblemName attribute?");
					return;
				}

				Console.WriteLine($"Year {year}, day {day}: {problemName.Name}");

				string[] files = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, $"{year}", $"Day{day.ToString().PadLeft(2, '0')}"));
				IEnumerable<string> possiblePaths = files.Where(file => file.EndsWith("input.txt"));

				if(!possiblePaths.Any())
				{
					Console.WriteLine("No input.txt found.");
					return;
				}

				string inputPath = possiblePaths.First();

				string input = File.ReadAllText(inputPath).ReplaceLineEndings();

				Console.WriteLine(solver.PartOne(input));

				var partTwo = solver.PartTwo(input);

				if(partTwo != null)
				{
					Console.WriteLine(partTwo);
				}
			}, yearArgument, dayArgument);

			rootCommand.AddCommand(solutionCommand);

			return await rootCommand.InvokeAsync(args);
		}
    }
}