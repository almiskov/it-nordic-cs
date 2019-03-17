using System;

namespace Mirroring
{
	class Program
	{
		static void Main(string[] args)
		{
			string text = ReadUserText();

			string mirroredText = GetMirroredText(text);

			Console.WriteLine("Отражённый текст в нижнем регистре:");
			Console.WriteLine(mirroredText.ToLower());

			Console.ReadKey();
		}

		static string ReadUserText()
		{
			Console.WriteLine("Введите непустую строку:");

			string text;

			while (true)
			{
				text = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(text))
					Console.WriteLine("Вы ввели пустую строку. Попробуйте ещё раз.");
				else
					return text;
			}
		}

		static string GetMirroredText(string text)
		{
			string mirroredText = string.Empty;

			for(int i = text.Length - 1; i >= 0; i--)
			{
				mirroredText += text[i];
			}

			return mirroredText;
		}
	}
}
