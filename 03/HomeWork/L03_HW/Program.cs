using L03_HW.Properties;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;

namespace L03_HW
{
	class Program
	{
		static void Main(string[] args)
		{
			InitializeConsole(args);

			string[] namesArray = new string[3];
			byte[] agesArray = new byte[namesArray.Length];

			AskNames(namesArray);
			AskAges(agesArray);
			ShowInfoInYears(namesArray, agesArray, 4);

			Console.ReadKey();
		}

		static void InitializeConsole(string[] args)
		{
			CultureInfo cultureInfo = CultureInfo.InvariantCulture;

			if (args?.Length > 0)
			{
				try
				{
					cultureInfo = CultureInfo.CreateSpecificCulture(args[0]);
				}
				catch (Exception e)
				{
					Debug.WriteLine(e.ToString());
				}
			}

			Thread.CurrentThread.CurrentCulture = cultureInfo;
			Thread.CurrentThread.CurrentUICulture = cultureInfo;
			Console.InputEncoding = Encoding.Unicode;
			Console.OutputEncoding = Encoding.Unicode;
		}

		static void AskNames(string[] namesArray)
		{
			for (int i = 0; i < namesArray.Length; i++)
			{
				Console.Write(Resources.InputPersonNameRequest, i + 1);
				namesArray[i] = Console.ReadLine();
			}
		}

		static void AskAges(byte[] agesArray)
		{
			for (int i = 0; i < agesArray.Length; i++)
			{
				while (true)
				{
					Console.Write(Resources.InputPersonAgeRequest, i + 1);
					if (byte.TryParse(Console.ReadLine(), out byte age) && age <= 130)
					{
						agesArray[i] = age;
						break;
					}
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(Resources.IncorrectDataStatement);
					Console.ResetColor();
				}
			}
		}

		static void ShowInfoInYears(string[] namesArray, byte[] agesArray, byte yearsLater)
		{
			Console.WriteLine();
			Console.WriteLine(Resources.SeveralYearsLaterStatement, yearsLater);

			for (int i = 0; i < namesArray.Length; i++)
			{
				Console.WriteLine(Resources.PersonSummary, namesArray[i], yearsLater, agesArray[i] + yearsLater);
			}
		}

	}
}
