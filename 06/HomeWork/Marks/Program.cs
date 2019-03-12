using System;

namespace Marks
{
	class Program
	{
		static void Main(string[] args)
		{
			int precision = 1;
			string averageDayMarkString = "Средний балл за день";
			string averageWeekMarkString = "Средний балл за неделю";

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
					Console.WriteLine($"{averageDayMarkString} {i + 1}: {Math.Round(sumForDay / marks[i].Length, precision).ToString($"F{precision}")}");
				}
				else
				{
					Console.WriteLine($"{averageDayMarkString} {i + 1}: N/A");
				}
			}

			Console.WriteLine($"{averageWeekMarkString}: {Math.Round(sumForWeek / marksCounter, precision)}");
			Console.ReadKey();
		}
	}
}