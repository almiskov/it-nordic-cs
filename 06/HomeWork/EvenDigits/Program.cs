using System;

namespace EvenDigits
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine($"Введите положительное натуральное число не более {int.MaxValue}:");

			int inputNumber = GetUserInput();

			byte numberOfEvenDigits = CountEvenDigits(inputNumber);
			byte numberOfOddDigits = CountOddDigits(inputNumber);

			Console.WriteLine($"В числе {inputNumber}:\n" +
				$" - чётных цифр {numberOfEvenDigits};\n" +
				$" - нечётных цифр {numberOfOddDigits}.");

			Console.ReadKey();
		}

		static int GetUserInput()
		{
			int inputNumber;

			while (true)
			{
				try
				{
					inputNumber = int.Parse(Console.ReadLine());

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

		static byte CountEvenDigits(int number)
		{
			byte counter = 0;

			do
			{
				if (number % 2 == 0)
				{
					counter++;
				}

				number /= 10;

			} while (number > 0);

			return counter;
		}

		static byte CountOddDigits(int number)
		{
			byte counter = 0;

			do
			{
				if (number % 2 == 1)
				{
					counter++;
				}

				number /= 10;

			} while (number > 0);

			return counter;
		}
	}
}
