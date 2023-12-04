using System.Security.Cryptography;

namespace AdventOfCode.Y2015.Day04;

[ProblemName("The Ideal Stocking Stuffer")]
class Solution : Solver
{

	public object PartOne(string input)
	{
		return GetItterationCountForZero(input, 5);
	}

	public object PartTwo(string input)
	{
		return GetItterationCountForZero(input, 6);
	}

	public static int GetItterationCountForZero(string input, int zeroCount)
	{
		int result = 0;

		Parallel.ForEach(InfiniteCounter(),
			(i, state) => {
				MD5 md5 = MD5.Create();

				byte[] hash = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes($"{input}{i}"));

				if(Convert.ToHexString(hash).StartsWith(new string('0', zeroCount)))
				{
					result = i;
					state.Stop();
				}
			});

		return result;
	}

	private static IEnumerable<int> InfiniteCounter()
	{
		for(int i = 0; ; i++)
		{
			yield return i;
		}
	}

}
				