using System;

namespace _for
{
	class Program
	{
		static void Main(string[] args)
		{
			int precision = 2;

			var marks = new[]
			{
				new [] { 2, 3, 3, 2, 3 },
				new [] { 2, 4, 5, 3 },
				null,
				new [] { 5, 5, 5, 5 },
				new [] { 4 }
			};

			double sumForDay;
			double sumForWeek = 0;
			int marksCounter = 0;

			for (int i = 0; i < marks.Length; i++)
			{
				sumForDay = 0;

				if (marks[i] != null)
				{
					for (int j = 0; j < marks[i].Length; j++)
					{
						sumForDay += marks[i][j];
						sumForWeek += marks[i][j];
						marksCounter++;
					}
					Console.WriteLine($"Средний балл за день {i + 1}: { Math.Round(sumForDay / marks[i].Length, precision)}");
				}
				else
				{
					Console.WriteLine($"Средний балл за день {i + 1}: N/A");
				}
			}

			Console.WriteLine($"Средний балл за неделю: {Math.Round(sumForWeek / marksCounter, precision)}");
			Console.ReadKey();
		}
	}
}


/*


*/
