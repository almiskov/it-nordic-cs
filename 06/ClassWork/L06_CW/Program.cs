using System;

namespace L06_CW
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите строку или введите exit для выхода");

			string str;
			do
			{
				str = Console.ReadLine();

				if (str == "exit")
					break;

				if (str.Length <= 15)
				{
					Console.WriteLine($"Длина строки равна {str.Length}");
					continue;
				}

				Console.WriteLine("Слишком длинная строка. Попробуйте снова.");
			} while (true);

			Console.WriteLine("Вышли из цикла");
		}
	}
}
