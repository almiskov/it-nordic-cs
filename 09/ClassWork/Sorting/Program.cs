using System;
using System.Diagnostics;

namespace Sorting
{
	class Program
	{
		static void Main(string[] args)
		{
			int length = 1000;

			for(int i = 0; i < 10; i++)
			{
				int[] initialArray = GetTestArray(length, int.MaxValue);

				//WriteArrayState("Initial state:\t", initialArray);

				int[] bubbleSortedArray = (int[])initialArray.Clone();
				int[] dotnetSortedArray = (int[])initialArray.Clone();

				var stopwatch = new Stopwatch();

				stopwatch.Start();

				BubbleSort(bubbleSortedArray);

				stopwatch.Stop();

				Console.WriteLine($"Length: {length}. Bubble sorting took {stopwatch.ElapsedMilliseconds} ms");

				//stopwatch.Restart();

				//Array.Sort(dotnetSortedArray);

				//stopwatch.Stop();

				//Console.WriteLine($"Length: {length}. DotNet sorting took {stopwatch.ElapsedMilliseconds} ms");

				length = length * 2;
			}






			//WriteArrayState("Sorted state:\t", bubbleSortedArray);


		}

		private static int[] GetTestArray(int length, int maxValue)
		{
			var result = new int[length];

			var rnd = new Random();

			for (int i = 0; i < result.Length; i++)
			{
				result[i] = rnd.Next(maxValue);
			}

			return result;
		}

		private static void WriteArrayState(string message, int[] array)
		{
			Console.Write(message);
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write($"{array[i]:00} ");
			}
			Console.WriteLine();
		}

		private static void BubbleSort(int[] array)
		{
			int temp;

			for (int i = 0; i < array.Length - 1; i++)
			{
				for (int j = 0; j < array.Length - 1 - i; j++)
				{
					if (array[j] > array[j + 1])
					{
						temp = array[j];
						array[j] = array[j + 1];
						array[j + 1] = temp;
					}
				}
			}
		}
	}
}
