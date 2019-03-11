using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
	public class AppIO
	{
		private readonly ConsoleWriter writer;
		private readonly int maxParameterValue = 1000;

		public AppIO(ConsoleWriter writer)
		{
			this.writer = writer;
		}

		public void WriteTitle(string[] namesArray)
		{
			writer.WriteLineYellow("Выберите тип фигуры:");

			byte startIndex = 1;
			foreach(string name in namesArray)
			{
				writer.WriteLineYellow($"{startIndex++}. {name}");
			}
		}

		public void WriteResult(double surfaceArea, double perimeter)
		{
			writer.WriteLineGreen($"Площадь поверхности: {surfaceArea}");
			writer.WriteLineGreen($"Периметр: {perimeter}");
		}

		public void WriteParameterRequest(string requestText)
		{
			writer.WriteLineBlue(requestText + $" (не более {maxParameterValue}):");
		}

		public double ReadParameter()
		{
			while (true)
			{
				if(double.TryParse(Console.ReadLine(), out double parameter) && parameter > 0 && parameter <= double.MaxValue)
				{
					if (parameter > maxParameterValue)
						throw new ArgumentOutOfRangeException("Input value", $"The value can't be more than {maxParameterValue}");

					return parameter;
				}
				writer.WriteLineRed("Некорректные данные. Повторите ввод.");
			}
		}

		public int ReadShapeNumber(int maxIndex)
		{
			while (true)
			{
				if(int.TryParse(Console.ReadLine(), out int shapeNumber) && shapeNumber > 0 && shapeNumber <= maxIndex)
				{
					return shapeNumber - 1;
				}
				writer.WriteLineRed("Введено недопустимое значение.");
			}
		}
	}
}
