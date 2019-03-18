using System;
using System.Collections.Generic;

namespace _Queue
{
	class Program
	{
		static void Main(string[] args)
		{
			Queue<int> intQueue = new Queue<int>();

			Console.WriteLine("Вводите числа, добавляйте в очередь по нажатию Enter. run - расчёт. exit - выход");

			string inputString;
			int inputNumber;
			int currentInt;

			while (true)
			{
				inputString = Console.ReadLine().Trim().ToLower();

				if (inputString == "run")
				{
					while(intQueue.Count > 0)
					{
						currentInt = intQueue.Dequeue();
						Console.WriteLine($"Квадратный корень из {currentInt} равен {Math.Sqrt(currentInt):0.000}");
					}

					Console.WriteLine("Очередь пуста. Вводите числа, добавляйте в очередь по нажатию Enter. run - расчёт. exit - выход");
				}
				else if (inputString == "exit")
				{
					Console.WriteLine($"В очереди на данный момент {intQueue.Count} элементов.");
					break;
				}
				else
				{
					if (int.TryParse(inputString, out inputNumber))
					{
						intQueue.Enqueue(inputNumber);
					}
					else
					{
						Console.WriteLine("Введено не целое число. Повторите ввод.");
					}
				}
			}
		}
	}
}
