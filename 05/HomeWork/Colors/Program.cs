using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace FavoriteColors
{
	class Program
	{
		[Flags]
		enum Color
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
			DarkBlue = 0x01 << 9,
			LightGreen = 0x01 << 10
		}

		static void Main(string[] args)
		{
			InitializeConsole();

			Color allColors = (Color)(Math.Pow(2, Enum.GetNames(typeof(Color)).Length) - 1); // like 0000...00111111111

			ShowListOfColors("Цвета палитры", allColors);

			AskUsersFavouriteColorsAndProcessIt(allColors, out Color favouriteColors, out Color unFavouriteColors);

			ShowListOfColors("Любимые цвета", favouriteColors);
			ShowListOfColors("Не любимые цвета", unFavouriteColors);

			Console.ReadKey();
		}

		static void InitializeConsole()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			Console.InputEncoding = Encoding.Unicode;
			Console.OutputEncoding = Encoding.Unicode;
		}

		static void ShowListOfColors(string description, Color listOfColors)
		{
			Console.WriteLine($"{description}: {listOfColors}");
		}

		static void AskUsersFavouriteColorsAndProcessIt(Color allColors, out Color favouriteColors, out Color unFavouriteColors)
		{
			favouriteColors = 0x00;
			unFavouriteColors = allColors;

			Array arrayOfAllColors = Enum.GetValues(typeof(Color));
			Color choosedColor;

			Console.WriteLine("Введите названия 4 цветов для добавления в избранное:");
			for (int i = 0; i < 4; i++)
			{
				while (true)
				{
					string usersChoise = Console.ReadLine();

					if (Enum.TryParse(typeof(Color), usersChoise, true, out object inputColor) &&
						!int.TryParse(usersChoise, out int result))
					{
						choosedColor = (Color)(0x01 << Array.IndexOf(arrayOfAllColors, inputColor));

						favouriteColors = favouriteColors | choosedColor;

						if ((unFavouriteColors & choosedColor) == choosedColor)
							unFavouriteColors = unFavouriteColors ^ choosedColor;

						break;
					}

					Console.WriteLine("Введены некорректные данные.");
				}
			}
		}
	}
}
