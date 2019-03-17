using System;

namespace WordCounting
{
	class Program
	{
		static void Main(string[] args)
		{
			string userText = ReadUserText();
			char firstLetter = ReadUserLetter();

			int numberOfWords = CountWordsStartsWithLetter(firstLetter, userText);

			Console.WriteLine($"Количество слов, начинающихся с буквы \'{firstLetter}\': {numberOfWords}");

			Console.ReadKey();
		}

		static string ReadUserText()
		{
			Console.WriteLine("Введите строку не менее чем из двух слов:");

			string text;
			int numberOfWords;

			while (true)
			{
				text = Console.ReadLine();

				numberOfWords = text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Length;

				if (numberOfWords < 2)
					Console.WriteLine("Введите как минимум 2 слова");
				else
					return text;
			}
		}

		static char ReadUserLetter()
		{
			Console.WriteLine("Введите букву для подсчёта количества слов, начинающихся с неё:");

			string inputLetter;

			while (true)
			{
				inputLetter = Console.ReadLine();

				if (inputLetter.Length != 1)
					Console.WriteLine("Введите ОДНУ букву.");
				else if (!char.IsLetter(inputLetter[0]))
					Console.WriteLine("Введена не буква.");
				else
					return inputLetter[0];
			}
		}

		static int CountWordsStartsWithLetter(char firstLetterOfTheWord, string text)
		{
			string[] words = text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

			int counter = 0;

			for (int i = 0; i < words.Length; i++)
			{
				if (words[i].ToLower().StartsWith(char.ToLower(firstLetterOfTheWord)))
					counter++;
			}

			return counter;
		}
	}
}
