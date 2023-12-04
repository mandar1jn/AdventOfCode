using System.Text.RegularExpressions;

namespace AdventOfCode.Y2015.Day05;

[ProblemName("Doesn't He Have Intern-Elves For This?")]
class Solution : Solver
{

	public object PartOne(string input) =>
	(
		from line in input.Split(Environment.NewLine)
		let vowels = line.Count(character => "aeiou".Contains(character))
		let doubles = Enumerable.Range(0, line.Length - 1).Any(i => line[i] == line[i + 1])
		let specific = "ab cd pq xy".Split(" ").Any(line.Contains)
		select vowels >= 3 && doubles && !specific
	).Where(result => result).Count();

	public object PartTwo(string input) =>
	(
		from line in input.Split(Environment.NewLine)
		let repeat = Enumerable.Range(0, line.Length - 1).Any(i => line.IndexOf(line.Substring(i, 2), i + 2) >= 0)
		let space = Enumerable.Range(0, line.Length - 2).Any(i => line[i] == line[i + 2])
		select repeat && space
	).Where(result => result).Count();

}
				