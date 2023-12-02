namespace AdventOfCode;

[AttributeUsage(AttributeTargets.Class)]
internal class ProblemNameAttribute : Attribute
{
	public string Name;

	public ProblemNameAttribute(string name)
	{
		this.Name = name;
	}
}
