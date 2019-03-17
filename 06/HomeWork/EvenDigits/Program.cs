using System;
using System.Collections.Generic;

namespace EvenDigits
{
	class Program
	{
		// тут в целом всё достаточно криво и есть небольшой косяк в работе (лучше с нуля цифру не начинать,
		// а то не справедливо будет с методом с делением на 10)
		// но в целом все методы в почти одинаковых условиях тестировались (кроме деления на 10 - там в метод надо string передавать,
		// а потом обратно к uint приводить)

		// Короче, рейтинг по скорости такой:
		// 1. Обычное сравнение с char типа ch == '1' || ch == '3' и т.д.
		// 2. С делением на 10
		// 3. С использованием List<>, метод Contains
		// 4. С использованием Array.Exists

		delegate void Method(string inputNumber, out byte numberOfOddDigits, out byte numberOfEvenDigits);

		static void Main(string[] args)
		{
			Console.WriteLine($"Введите положительное натуральное число не более {uint.MaxValue}:");

			uint inputNumber = GetUserInputAsUint();

			byte numberOfOddDigits = 0;
			byte numberOfEvenDigits = 0;

			TimeForTheMethod("С использованием char[], метод Array.Exists", inputNumber.ToString(), out numberOfOddDigits, out numberOfEvenDigits, CountOddAndEvenNumbersWithPredicate);
			TimeForTheMethod("С последовательным делением на 10", inputNumber.ToString(), out numberOfOddDigits, out numberOfEvenDigits, CountOddAndEvenNumbersWithDividing);
			TimeForTheMethod("С использованием List<char>, метод Contains", inputNumber.ToString(), out numberOfOddDigits, out numberOfEvenDigits, CountOddAndEvenNumbersWithList);
			TimeForTheMethod("С использованием простого сравнения с '1', '3' и т.д.", inputNumber.ToString(), out numberOfOddDigits, out numberOfEvenDigits, CountOddAndEvenNumbersWithJustDigitsAsChars);
			TimeForTheMethod("С конвертированием в byte[].", inputNumber.ToString(), out numberOfOddDigits, out numberOfEvenDigits, CountOddAndEvenNumbersWithConvertingToByteArray);

			Console.WriteLine($"В числе {inputNumber}:\n" +
					$" - чётных цифр {numberOfEvenDigits};\n" +
					$" - нечётных цифр {numberOfOddDigits}.");

			Console.WriteLine();

			Console.ReadKey();
		}

		static void TimeForTheMethod(string description, string inputNumber, out byte numberOfOddDigits, out byte numberOfEvenDigits, Method method)
		{
			int times = 20;                 // сколько раз произвести повторения для подсчёта среднего значения времени
			int timesToRepeat = 1000000;    // сколько раз повторить расчёт чётных и нечётных значений соответствующим методом

			numberOfOddDigits = 0;
			numberOfEvenDigits = 0;

			TimeSpan timeSpan = TimeSpan.Zero;

			for (int i = 0; i < times; i++)
			{
				DateTime start = DateTime.Now;

				for (int j = 0; j < timesToRepeat; j++)
				{
					method(inputNumber.ToString(), out numberOfOddDigits, out numberOfEvenDigits);
				}

				DateTime finish = DateTime.Now;

				timeSpan += finish - start;
			}

			Console.WriteLine($"Метод: {description.ToLower()}.\nСреднее время на поиск ({timesToRepeat} повторений): {((timeSpan / times).TotalMilliseconds):0.0} мс\n");
		}

		#region Test methods

		static void CountOddAndEvenNumbersWithJustDigitsAsChars(string inputNumberAsString, out byte numberOfOddDigits, out byte numberOfEvenDigits)
		{
			numberOfOddDigits = 0;

			for (byte i = 0; i < inputNumberAsString.Length; i++)
			{
				if (inputNumberAsString[i] == '1' ||
					inputNumberAsString[i] == '3' ||
					inputNumberAsString[i] == '5' ||
					inputNumberAsString[i] == '7' ||
					inputNumberAsString[i] == '9')

					numberOfOddDigits++;
			}

			numberOfEvenDigits = (byte)(inputNumberAsString.Length - numberOfOddDigits);
		}

		static void CountOddAndEvenNumbersWithDividing(string inputNumberAsString, out byte numberOfOddDigits, out byte numberOfEvenDigits)
		{
			uint inputNumberAsUint = uint.Parse(inputNumberAsString);
			numberOfOddDigits = 0;

			do
			{
				if (inputNumberAsUint % 2 == 0)
				{
					numberOfOddDigits++;
				}

				inputNumberAsUint /= 10;

			} while (inputNumberAsUint > 0);

			numberOfEvenDigits = (byte)(inputNumberAsString.Length - numberOfOddDigits);
		}

		static void CountOddAndEvenNumbersWithList(string inputNumberAsString, out byte numberOfOddDigits, out byte numberOfEvenDigits)
		{
			List<char> oddDigits = new List<char> { '1', '3', '5', '7', '9' };
			numberOfOddDigits = 0;

			for (byte i = 0; i < inputNumberAsString.Length; i++)
			{
				if (oddDigits.Contains(inputNumberAsString[i]))
					numberOfOddDigits++;
			}

			numberOfEvenDigits = (byte)(inputNumberAsString.Length - numberOfOddDigits);
		}

		static void CountOddAndEvenNumbersWithPredicate(string inputNumberAsString, out byte numberOfOddDigits, out byte numberOfEvenDigits)
		{
			char[] oddDigits = { '1', '3', '5', '7', '9' };
			numberOfOddDigits = 0;

			for (byte i = 0; i < inputNumberAsString.Length; i++)
			{
				if (Array.Exists(oddDigits, (digit) => digit == inputNumberAsString[i]))
					numberOfOddDigits++;
			}

			numberOfEvenDigits = (byte)(inputNumberAsString.Length - numberOfOddDigits);
		}

		static void CountOddAndEvenNumbersWithConvertingToByteArray(string inputNumberAsString, out byte numberOfOddDigits, out byte numberOfEvenDigits)
		{
			char[] digitsAsCharArray = inputNumberAsString.ToCharArray();
			byte[] digitsAsIntArray = Array.ConvertAll<char, byte>(digitsAsCharArray, (i) => byte.Parse(i.ToString()));

			numberOfOddDigits = 0;

			for (byte i = 0; i < digitsAsCharArray.Length; i++)
			{
				if (digitsAsIntArray[i] % 2 == 1)
					numberOfOddDigits++;
			}

			numberOfEvenDigits = (byte)(inputNumberAsString.Length - numberOfOddDigits);
		}

		#endregion

		static uint GetUserInputAsUint()
		{
			uint inputNumber;

			while (true)
			{
				if (uint.TryParse(Console.ReadLine(), out inputNumber) && inputNumber > 0 && inputNumber <= uint.MaxValue)
				{
					return inputNumber;
				}
				else
				{
					Console.WriteLine("Некорректный ввод. Повторите согласно условию.");
				}
			}
		}

		#region other things

		static uint GetUserInput()
		{
			uint inputNumber;

			while (true)
			{
				try
				{
					inputNumber = uint.Parse(Console.ReadLine());

					if (inputNumber == 0)
					{
						Console.WriteLine("0 - ни положительное, ни отрицательное число. Повторите ввод.");
					}
					else
					{
						return inputNumber;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine($"{e.GetType()}: {e.Message}" +
						$" Повторите ввод.");
				}
			}
		}

		static byte CountEvenDigits(uint number)
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

		static byte CountOddDigits(uint number)
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

		#endregion
	}
}
