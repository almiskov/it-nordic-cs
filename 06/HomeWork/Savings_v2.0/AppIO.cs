using System;
using System.Threading;

namespace Savings_v2._0
{
	class AppIO
	{
		private readonly ConsoleWriter writer;

		public AppIO(ConsoleWriter writer)
		{
			this.writer = writer;
		}

		#region Suggestions And Results Output Methods

		private void WriteSuggestion(string text)
		{
			writer.WriteLineYellow(text);
		}

		private void WriteResult(string text)
		{
			writer.WriteLineGreen(text);
		}

		public void WriteDaysToDesiredSumLeft(int daysToDesiredSumLeft)
		{
			WriteResult($"Необходимое количество дней для накопления желаемой суммы: {daysToDesiredSumLeft}");
		}

		#endregion

		#region Errors Output Methods

		private void WriteError(string text)
		{
			writer.WriteLineRed(text);
		}

		public void WriteDesiredSumIsAlreadyExistsError()
		{
			WriteError("У вас уже есть желаемая сумма.");
		}

		#endregion

		#region Read User Input Methods

		private decimal ReadPositiveSum()
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
						WriteError("Введённая сумма должна быть положительным числом.");
					}
				}
				catch (Exception e)
				{
					WriteError($"Ошибка: {e.GetType()}: {e.Message} Повторите ввод.");
					// throw;
				}
			}
		}

		public decimal ReadFirstPayment()
		{
			WriteSuggestion("Введите сумму первоначального взноса в рублях:");

			return ReadPositiveSum();
		}

		public decimal ReadDailyPercantageOfIncome()
		{
			WriteSuggestion($"Введите ежедневный процент дохода в виде десятичной дроби(1 % = 0{Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator}01):");

			return ReadPositiveSum();

		}

		public decimal ReadDesiredSum()
		{
			WriteSuggestion("Введите желаемую сумму накопления в рублях:");

			return ReadPositiveSum();
		}

		#endregion
	}
}
