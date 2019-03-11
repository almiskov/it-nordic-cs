using System;

namespace _while
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] array = { 1, 2, 3, 4, 2, 5, 4, 234, 4, 5, 56, 6, 56, 34 };

			int sum = 0;
			int counter = 0;

			while (counter < array.Length)
			{
				sum += array[counter];
				Console.WriteLine($"Итерация {counter}, сумма {sum}");
				counter++;
			}
		}
	}
}
