using System;

namespace Savings_v2._0
{
	class AppIO
	{
		private readonly ConsoleWriter writer;

		public AppIO(ConsoleWriter writer)
		{
			this.writer = writer;
		}

		public void WriteSuggestion(string text)
		{
			writer.WriteLineYellow(text);
		}

		public void WriteResult(string text)
		{
			writer.WriteLineGreen(text);
		}

		public void WriteError(string text)
		{
			writer.WriteLineRed(text);
		}

		public decimal ReadUserInput()
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
						writer.WriteLineRed("Введено неверное значение. Повторите ввод.");
					}
				}
				catch (Exception e)
				{
					writer.WriteLineRed($"Ошибка: {e.GetType()}. Повторите ввод.");
					// throw;
				}
			}
		}
	}
}
