using System;

namespace L03_CW
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] names = new string[5];

			for (int i = 0; i < names.Length; i++)
			{
				names[i] = Console.ReadLine();
			}

			for (int i = 0; i < names.Length; i++)
			{
				Console.WriteLine(names[i]);
			}
		}
	}
}
