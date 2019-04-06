using System;

namespace Errors
{
	class Program
	{
		static void Main(string[] args)
		{
			using(ErrorList inputErrors = new ErrorList("Input error"))
			{
				inputErrors.Add("Wrong value");
				inputErrors.Add("Wrong sign");
				inputErrors.Add("Wrong arms");

				foreach (string s in inputErrors)
					Console.WriteLine($"{inputErrors.Category}: {s}");
			}
		}
	}
}
