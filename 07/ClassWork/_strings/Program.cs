using System;

namespace _strings
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите два числа:");

			double a = double.Parse(Console.ReadLine());
			double b = double.Parse(Console.ReadLine());

			Console.WriteLine(a.ToString("0.00") + " * " + b.ToString("0.00") + " = " + (a * b).ToString("0.00"));

			Console.WriteLine(string.Format("{0:0.00} + {1:0.00} = {2:0.00}", a, b, a + b));
			Console.WriteLine("{0:0.00} + {1:0.00} = {2:0.00}", a, b, a + b);

			Console.WriteLine($"{a:0.00} - {b:0.00} = {(a - b):0.00}");
		}
	}
}
