using System;
using System.Collections.Generic;

namespace Lists
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> intList = new List<int> { 40, 30, 20, 10 };

			intList.AddRange(new int[] { 5, 6, 7, 8, 9 });
			Console.WriteLine(string.Join(", ", intList));

			intList.RemoveRange(2, intList.Count - 2);
			Console.WriteLine(string.Join(", ", intList));

			Console.ReadKey();
		}
	}
}
