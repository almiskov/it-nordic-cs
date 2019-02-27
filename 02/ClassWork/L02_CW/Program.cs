using System;

namespace L02_CW
{
	class Program
	{
		static void Main(string[] args)
		{
			int x = 4;
			float y = 0.5f;
			short z = 4;
			var result = x * y / 1;
			Type type = result.GetType();
			Console.WriteLine($"Result is {result}. " + $"Type of result is {type.ToString()}.");
			Console.ReadKey();
		}
	}
}
