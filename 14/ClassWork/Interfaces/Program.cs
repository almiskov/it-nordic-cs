using System;

namespace Interfaces
{
	class Program
	{
		static void Main(string[] args)
		{
			using(var errorList = new ErrorList("Some errors category"))
			{
				errorList.Add("Some error");
				errorList.Add("Another error");
				errorList.Add("Third error");

				//foreach (string s in errorList)
				//{
				//	Console.WriteLine($"{errorList.Category}: {s}");
				//}

				errorList.WriteToConsole();

			}
		}
	}
}
