using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace FavoriteColors
{
	class Program
	{
		[Flags]
		enum Colors
		{
			Black = 0x01,
			Blue = 0x01 << 1,
			Cyan = 0x01 << 2,
			Gray = 0x01 << 3,
			Green = 0x01 << 4,
			Magenta = 0x01 << 5,
			Red = 0x01 << 6,
			White = 0x01 << 7,
			Yellow = 0x01 << 8,
			LightBlue = 0x01 << 9,
			DarkGreen = 0x01 << 10
		}

		static void Main(string[] args)
		{
			InitializeConsole();

			// Выводим пользователю цвета палитры для выбора
			string[] colorsNamesArray = Enum.GetNames(typeof(Colors));
			Console.WriteLine("Цвета палитры:");
			for(int i = 0; i < colorsNamesArray.Length; i++)
				Console.WriteLine($"{i}. {colorsNamesArray[i]}");

			// Задаём начальное значение для любимых цветов а-ля Colors.None
			Colors favouriteColors = 0x00;

			// Предлагаем выбрать 4 цвета из списка
			Console.WriteLine("Добавьте 4 цвета в избранное:");
			for(int i = 0; i < 4; i++)
			{
				while (true)
				{
					if(int.TryParse(Console.ReadLine(), out int choosedColorNumber) &&
						choosedColorNumber >= 0 && choosedColorNumber < Enum.GetNames(typeof(Colors)).Length)
					{
						favouriteColors = favouriteColors | (Colors)(0x01 << choosedColorNumber);
						break;
					}
					Console.WriteLine("Введено некорректное значение.");
				}
			}

			// Выводим выбранные цвета
			Console.WriteLine($"\nЛюбимые цвета:\n{favouriteColors}");

			// Суть следующего кода в том, чтобы взять двоичное значение favouriteColors, инвертировать его биты через ~,
			// затем превратить в ноль все "лишние" разряды (номера которых больше числа элементов в Colors) с помощью ^.
			// Это и будут флаги для нелюбимых цветов.
			// Всё ради спокойного добавления новых цветов в Colors или удаления ненужных

			int patternPositionValue = 1; // определяет значение для i-го разряда шаблона
			string patternIntValueAsString = string.Empty; // хранит двоичное представление шаблона

			for (int i = 32; i > 0; i--)
			{
				if (i <= Enum.GetNames(typeof(Colors)).Length)	// записываем в шаблон сначала единицы
					patternPositionValue = 0;                   // затем в зависимости от количества элементов в Colors - нули

				patternIntValueAsString += patternPositionValue;
			}

			// получаем значение шаблона в виде 1111111111111111111110000000000
			// затем с его помощью из инвертированного favouriteColors убираем те самые "лишние" единицы

			Colors unFavouriteColors = (Colors)((int)~favouriteColors ^ Convert.ToInt32(patternIntValueAsString, 2));

			// Выводим невыбранные цвета
			Console.WriteLine($"\nНелюбимые цвета:\n{unFavouriteColors}");

			Console.ReadKey();
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
