using System;

namespace stringMethods
{
	class Program
	{
		static void Main(string[] args)
		{
			string test = "my test string";
			string subString = test.Substring(5, 8);

			char ch = 'f';
			char.ToUpper(ch);

			Console.WriteLine(ch);
			Console.WriteLine(subString);
		}
	}
}