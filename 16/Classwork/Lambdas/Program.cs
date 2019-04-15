using System;

namespace Lambdas
{
	class Program
	{
		static void Main(string[] args)
		{
			Circle c = new Circle(3);

			// calculate surface area
			double surface = c.Calculate(r => Math.PI * Math.Pow(r, 2));

			// calculate perimeter
			double perimeter = c.Calculate(r => 2 * Math.PI * r);

			Console.WriteLine($"Surface of {nameof(c)} is {surface}");
			Console.WriteLine($"Perimeter of {nameof(c)} is {perimeter}");


			//Calculation calc = new Calculation(new int[] {-1, 1, 1, 11, 1, 1, 2 });

			//double avg = calc.CalcSingleValue(
			//	(int[] array) =>
			//	{
			//		int sum = 0;

			//		foreach (int i in array)
			//			sum += i;

			//		return sum / (double)array.Length;
			//	});

			//double max = calc.CalcSingleValue(
			//	(int[] array) =>
			//	{
			//		int m = array[0];

			//		foreach (int i in array)
			//			if (i > m) m = i;

			//		return m;
			//	});

			//double min = calc.CalcSingleValue(
			//	(int[] array) =>
			//	{
			//		int m = array[0];

			//		foreach (int i in array)
			//			if (i < m) m = i;

			//		return m;
			//	});

			//Console.WriteLine("Array is: " + String.Join(' ', calc.Array));
			//Console.WriteLine("Average is: " + avg);
			//Console.WriteLine("Max is: " + max);
			//Console.WriteLine("Max is: " + min);
		}
	}
}
