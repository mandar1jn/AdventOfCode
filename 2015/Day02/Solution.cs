namespace AdventOfCode.Y2015.Day02;

[ProblemName("I Was Told There Would Be No Math")]
internal class Solution : Solver
{
	public object PartOne(string input) =>
	(
		from nums in Parse(input)
		select 2 * (nums[0] * nums[1] + nums[1] * nums[2] + nums[0] * nums[2]) + nums[0] * nums[1]
	).Sum();

	public object PartTwo(string input) =>
	(
		from nums in Parse(input)
		select 2 * nums[0] + 2* nums[1] + nums[0] * nums[1] * nums[2]
	).Sum();

	private static IEnumerable<int[]> Parse(string input) =>
	(
		from line in input.Split(Environment.NewLine)
		let nums = line.Split("x")
		select nums.Select(num => int.Parse(num.ToString())).OrderBy(x => x).ToArray()
	);
}
