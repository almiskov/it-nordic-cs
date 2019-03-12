using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Savings
{
	class Program
	{
		static void Main(string[] args)
		{
			InitializeConsole();

			Console.WriteLine("Введите сумму первоначального взноса в рублях:");
			decimal firstPayment = ReadUserInput();

			Console.WriteLine($"Введите ежедневный процент дохода в виде десятичной дроби(1 % = 0{CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator}01):");
			decimal dailyPercantageOfIncome = ReadUserInput();

			Console.WriteLine("Введите желаемую сумму накопления в рублях:");
			decimal desiredSum = ReadUserInput();

			int daysToDesiredSumLeft = CountDays(firstPayment, dailyPercantageOfIncome, desiredSum);

			Console.WriteLine($"Необходимое количество дней для накопления желаемой суммы: {daysToDesiredSumLeft}");

			Console.ReadLine();
		}

		static decimal ReadUserInput()
		{
			decimal inputNumber;

			while (true)
			{
				try
				{
					inputNumber = decimal.Parse(Console.ReadLine().Replace(',', '.'));

					if (inputNumber > 0)
					{
						return inputNumber;
					}
					else
					{
						Console.WriteLine("Введено неверное значение. Повторите ввод.");
					}
				}
				catch (Exception e)
				{
					Console.WriteLine($"{e.GetType()}. Повторите ввод.");
				}
			}
		}

		static int CountDays(decimal firstPayment, decimal dailyPercantageOfIncome, decimal desiredSum)
		{
			int dayCounter = 0;
			decimal currentSum = firstPayment;

			if(firstPayment < desiredSum)
			{
				do
				{
					currentSum += currentSum * dailyPercantageOfIncome;
					dayCounter++;

				} while (currentSum < desiredSum);
			}
			else
			{
				Console.WriteLine("У вас уже есть желаемая сумма.");
			}

			return dayCounter;
		}

		static void InitializeConsole()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			Console.InputEncoding = Encoding.Unicode;
			Console.OutputEncoding = Encoding.Unicode;
		}
	}
}
