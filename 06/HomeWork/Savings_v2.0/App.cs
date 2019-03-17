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
			decimal firstPayment = appIO.ReadFirstPayment();
			decimal dailyPercantageOfIncome = appIO.ReadDailyPercantageOfIncome();
			decimal desiredSum = appIO.ReadDesiredSum();

			int daysToDesiredSumLeft = CountDays(firstPayment, dailyPercantageOfIncome, desiredSum);

			appIO.WriteDaysToDesiredSumLeft(daysToDesiredSumLeft);
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
				appIO.WriteDesiredSumIsAlreadyExistsError();
			}

			return dayCounter;
		}
	}
}
