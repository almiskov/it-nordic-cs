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
			double sumforWeek = 0f;

			for(int i = 0; i < marks.Length; i++)
			{
				sumForDay = 0;

				if(marks[i] != null)
				{
					for (int j = 0; j < marks[i].Length; j++)
					{
						sumForDay += marks[i][j];
					}
					double dayAverage = Math.Round(sumForDay / marks[i].Length, precision);

					Console.WriteLine($"Средняя оценка за день {i}: {dayAverage}");
					sumforWeek += dayAverage;

				}
			}

			Console.WriteLine($"Средняя оценка за неделю: {Math.Round(sumforWeek / marks.Length, precision)}");

			// доделать
		}
	}
}


	/*
		
	
	*/