using System;
using System.Text;

namespace DirtySpaces
{
	class Program
	{
		static void Main(string[] args)
		{
			string text = "   lorem ipsum    dolor sit   amet  ";
			Console.WriteLine(text);

			string cleanTextWithUpturnedWord = RemoveUnnecessarySpacesAndUpTheWordNumber(text, 2);
			Console.WriteLine(cleanTextWithUpturnedWord);

			Console.ReadKey();
		}

		static string RemoveUnnecessarySpacesAndUpTheWordNumber(string text, int wordNumberToUp)
		{
			text = text.Trim();

			StringBuilder builder = new StringBuilder(text.Length);

			int wordCounter = 0;
			bool isNewWordStarted;

			char previousChar = ' ';
			char currentChar;
			bool isUnnecessarySpace;

			for (int i = 0; i < text.Length; i++)
			{
				currentChar = text[i];

				isNewWordStarted = char.IsWhiteSpace(previousChar) && !char.IsWhiteSpace(currentChar);
				isUnnecessarySpace = char.IsWhiteSpace(previousChar) && char.IsWhiteSpace(currentChar);

				if (isNewWordStarted)
					wordCounter++;

				if (!isUnnecessarySpace)
				{
					if (wordCounter == wordNumberToUp)
						currentChar = char.ToUpper(currentChar);

					builder.Append(currentChar);
				}

				previousChar = currentChar;
			}

			return builder.ToString();
		}

		static string RemoveUnnecessarySpaces(string text)
		{
			text = text.Trim();

			StringBuilder builder = new StringBuilder(text.Length);

			char previousChar = ' ';
			char currentChar;

			bool isUnnecessarySpace;

			for(int i = 0; i < text.Length; i++)
			{
				currentChar = text[i];

				isUnnecessarySpace = char.IsWhiteSpace(previousChar) && char.IsWhiteSpace(currentChar);

				if (!isUnnecessarySpace)
				{
					builder.Append(currentChar);
				}

				previousChar = currentChar;
			}

			return builder.ToString();
		}

		static string UpTheWordNumber(string text, int wordNumberToUp)
		{
			StringBuilder builder = new StringBuilder(text.Length);

			int wordCounter = 0;
			bool isNewWord;

			char previousChar = ' ';
			char currentChar;

			for(int i = 0; i < text.Length; i++)
			{
				currentChar = text[i];

				isNewWord = char.IsWhiteSpace(previousChar) && !char.IsWhiteSpace(currentChar);

				if (isNewWord)
					wordCounter++;

				if (wordCounter == wordNumberToUp)
					currentChar = char.ToUpper(currentChar);

				builder.Append(currentChar);

				previousChar = currentChar;
			}

			return builder.ToString();
		}
	}
}
