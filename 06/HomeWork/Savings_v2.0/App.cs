using System.Threading;

namespace Savings_v2._0
{
	class App
	{
		private readonly AppIO appIO;

		public App(ConsoleWriter writer)
		{
			appIO = new AppIO(writer);
		}

		public void Run()
		{
			appIO.WriteSuggestion("Введите сумму первоначального взноса в рублях:");
			decimal firstPayment = appIO.ReadUserInput();

			appIO.WriteSuggestion($"Введите ежедневный процент дохода в виде десятичной дроби(1 % = 0{Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator}01):");
			decimal dailyPercantageOfIncome = appIO.ReadUserInput();

			appIO.WriteSuggestion("Введите желаемую сумму накопления в рублях:");
			decimal desiredSum = appIO.ReadUserInput();

			int daysToDesiredSumLeft = CountDays(firstPayment, dailyPercantageOfIncome, desiredSum);

			appIO.WriteResult($"Необходимое количество дней для накопления желаемой суммы: {daysToDesiredSumLeft}");
		}

		private int CountDays(decimal firstPayment, decimal dailyPercantageOfIncome, decimal desiredSum)
		{
			int dayCounter = 0;
			decimal currentSum = firstPayment;

			if (firstPayment < desiredSum)
			{
				do
				{
					currentSum += currentSum * dailyPercantageOfIncome;
					dayCounter++;

				} while (currentSum < desiredSum);
			}
			else
			{
				appIO.WriteError("У вас уже есть желаемая сумма.");
			}

			return dayCounter;
		}
	}
}
