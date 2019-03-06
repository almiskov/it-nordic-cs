using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace L04_HW
{
	class Program
	{
		[Flags]
		enum PackageSyzeType
		{
			None = 0x0,
			_1L = 0x1,
			_5L = 0x1 << 1,
			_20L = 0x1 << 2
		}

		static void Main(string[] args)
		{
			InitializeConsole();

			double requestedVolume = AskUserForVolume();

			FigureOutAmountOfPackages(requestedVolume, out int _20LPackagesAmount, 
														out int _5LPackagesAmount, out int _1LPackagesAmount);

			CheckAndShowUsedPackagesTypes(_20LPackagesAmount, _5LPackagesAmount, _1LPackagesAmount);

			Console.ReadKey();
		}

		static void InitializeConsole()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			Console.InputEncoding = Encoding.Unicode;
			Console.OutputEncoding = Encoding.Unicode;
		}

		static double AskUserForVolume()
		{
			Console.WriteLine($"Какой объём сока (в литрах) требуется упаковать? " +
							  $"Пример ввода: 10{CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator}4");

			int maxVolumeForRequest = int.MaxValue;

			while (true)
			{
				if(double.TryParse(Console.ReadLine(), out double requestedVolume) 
									&& requestedVolume > 0
									&& requestedVolume <= maxVolumeForRequest)
				{
					return requestedVolume;
				}

				Console.WriteLine($"Объём должен быть числом больше нуля и не более {maxVolumeForRequest}. Повторите ввод.");
			}
		}

		static void FigureOutAmountOfPackages(double requestedVolume, out int _20LPackagesAmount, 
											out int _5LPackagesAmount, out int _1LPackagesAmount)
		{
			int minRoundVolume = (int)Math.Ceiling(requestedVolume);

			_20LPackagesAmount = Math.DivRem(minRoundVolume, 20, out int remainder20LPackages);
			_5LPackagesAmount = Math.DivRem(remainder20LPackages, 5, out int remainder5LPackages);
			_1LPackagesAmount = remainder5LPackages;
		}

		static void CheckAndShowUsedPackagesTypes(int _20LPackagesAmount, int _5LPackagesAmount, int _1LPackagesAmount)
		{
			var usedPackagesTypes = PackageSyzeType.None;

			if (_20LPackagesAmount > 0)
				usedPackagesTypes = usedPackagesTypes | PackageSyzeType._20L;
			if (_5LPackagesAmount > 0)
				usedPackagesTypes = usedPackagesTypes | PackageSyzeType._5L;
			if (_1LPackagesAmount > 0)
				usedPackagesTypes = usedPackagesTypes | PackageSyzeType._1L;

			Console.WriteLine("Вам потребуются следующие контейнеры:");

			if ((usedPackagesTypes & PackageSyzeType._20L) == PackageSyzeType._20L)
				Console.WriteLine($"20 л: {_20LPackagesAmount} шт.".PadLeft(17));
			if ((usedPackagesTypes & PackageSyzeType._5L) == PackageSyzeType._5L)
				Console.WriteLine($"5 л: {_5LPackagesAmount} шт.".PadLeft(17));
			if ((usedPackagesTypes & PackageSyzeType._1L) == PackageSyzeType._1L)
				Console.WriteLine($"1 л: {_1LPackagesAmount} шт.".PadLeft(17));
		}

	}
}
