using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionaries
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, string> countryCapitalPairs = new Dictionary<string, string>
			{
				{ "Россия",			"Москва" },
				{ "Великобритания",	"Лондон" },
				{ "Китай",			"Пекин" },
				{ "США",			"Вашингтон" },
				{ "Тайланд",		"Бангкок" },
				{ "Германия",		"Берлин" },
				{ "Мексика",		"Мехико" }
			};

			KeyValuePair<string, string> currentCountryCapitalPair;
			string inputCapital;

			while (true)
			{
				currentCountryCapitalPair = countryCapitalPairs.ElementAt(new Random().Next(countryCapitalPairs.Count));

				Console.WriteLine($"Введите название столицы страны: {currentCountryCapitalPair.Key}");

				inputCapital = Console.ReadLine();

				if(currentCountryCapitalPair.Value == inputCapital)
				{
					Console.WriteLine("Правильно! Молодец!");
				}
				else
				{
					Console.WriteLine("Не верно! До свидания!");
					break;
				}
			}
		}
	}
}
