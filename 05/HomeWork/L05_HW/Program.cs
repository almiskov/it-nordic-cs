using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace L05_HW
{
	class Program
	{
		enum Shape
		{
			Circle,
			EquilateralTriangle,
			Rectangle
		}

		static void Main(string[] args)
		{
			InitializeConsole();
			
			Dictionary<Shape, string> shapeStringPairs = MakeDictionaryFromShapeEnum();
			Shape choosedShape = AskForShape(shapeStringPairs);

			try
			{
				ProcessChoosedShape(choosedShape, out double surfaceArea, out double perimeter);
				ShowResult(surfaceArea, perimeter);
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.WriteLine($"{e.GetType()}: {e.Message}");
				throw;
			}

			Console.ReadLine();
		}

		static void InitializeConsole()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			Console.InputEncoding = Encoding.Unicode;
			Console.OutputEncoding = Encoding.Unicode;
		}

		static Dictionary<Shape, string> MakeDictionaryFromShapeEnum()
		{
			Dictionary<Shape, string> shapeStringPairs = new Dictionary<Shape, string>
			{
				{ Shape.Circle, "Круг" },
				{ Shape.EquilateralTriangle, "Равносторонний треугольник" },
				{ Shape.Rectangle, "Прямоугольник" }
			};

			return shapeStringPairs;
		}

		static Shape AskForShape(Dictionary<Shape, string> shapeStringPairs)
		{
			Console.WriteLine("Выберите фигуру по номеру:");

			Shape[] shapesArray = (Shape[])Enum.GetValues(typeof(Shape));

			for(int i = 0; i < shapesArray.Length; i++)
			{
				Console.WriteLine($"{i + 1}. {shapeStringPairs[shapesArray[i]]}");
			}

			while (true)
			{
				if(byte.TryParse(Console.ReadLine(), out byte choosedNumberOfShape) && choosedNumberOfShape > 0 && choosedNumberOfShape <= shapesArray.Length)
				{
					Shape choosedShape = shapesArray[choosedNumberOfShape - 1];
					WriteLineWithGreen($"Выбран {shapeStringPairs[choosedShape].ToLower()}");
					return choosedShape;
				}
				WriteLineWithRed("Введён недопустимый номер. Повторите ввод.");
			}
		}

		static void ProcessChoosedShape(Shape choosedShape, out double surfaceArea, out double perimeter)
		{
			Console.WriteLine("Значение длины не должно превышать 1000!");

			switch (choosedShape)
			{
				case Shape.Circle:
				{
					AskCircleData(out double diameter);
					ProcessCircleData(diameter, out surfaceArea, out perimeter);
					break;
				}
				case Shape.EquilateralTriangle:
				{
					AskEquilateralTriangleData(out double triangleSide);
					ProcessEquilateralTriangleData(triangleSide, out surfaceArea, out perimeter);
					break;
				}
				case Shape.Rectangle:
				{
					AskRectangleData(out double height, out double width);
					ProcessRectangleData(height, width, out surfaceArea, out perimeter);
					break;
				}
				default:
					surfaceArea = 0;
					perimeter = 0;
					break;
			}
		}

		#region Methods to ask user for shape's characteristics

		static void AskCircleData(out double diameter)
		{
			Console.Write("Введите диаметр круга: ");
			diameter = AskShapeParameter();
		}

		static void AskEquilateralTriangleData(out double triangleSide)
		{
			Console.Write("Введите длину стороны равностороннего треугольника: ");
			triangleSide = AskShapeParameter();
		}

		static void AskRectangleData(out double height, out double width)
		{
			Console.Write("Введите высоту прямоугольника: ");
			height = AskShapeParameter();
			Console.Write("Введите ширину прямоугольника: ");
			width = AskShapeParameter();
		}

		static double AskShapeParameter()
		{
			// допустим, значение параметра фигуры не может быть больше 1000

			while (true)
			{
				if (double.TryParse(Console.ReadLine(), out double parameter) && parameter >= 0 && parameter <= double.MaxValue)
				{
					if (parameter > 1000)
						throw new ArgumentOutOfRangeException("Значение параметра не может быть больше 1000.");

					return parameter;
				}
				WriteLineWithRed("Ошибка! Введено неверное значение. Повторите ввод");
			}
		}

		#endregion

		#region Methods to process input charateristics of shapes

		static void ProcessCircleData(double diameter, out double surfaceArea, out double perimeter)
		{
			surfaceArea = Math.Round(Math.PI * Math.Pow(diameter, 2) / 4, 2, MidpointRounding.AwayFromZero);
			perimeter = Math.Round(Math.PI * diameter, 2, MidpointRounding.AwayFromZero);
		}

		static void ProcessEquilateralTriangleData(double triangleSide, out double surfaceArea, out double perimeter)
		{
			
			surfaceArea = Math.Round(Math.Pow(triangleSide, 2) * Math.Sqrt(3) / 4, 2, MidpointRounding.AwayFromZero);
			perimeter = Math.Round(triangleSide * 3, 2, MidpointRounding.AwayFromZero);
		}

		static void ProcessRectangleData(double height, double width, out double surfaceArea, out double perimeter)
		{
			surfaceArea = Math.Round(height * width, 2, MidpointRounding.AwayFromZero);
			perimeter = Math.Round(2 * (height + width), 2, MidpointRounding.AwayFromZero);
		}

		#endregion

		static void ShowResult(double surfaceArea, double perimeter)
		{
			WriteLineWithYellow($"Площадь: {surfaceArea}");
			WriteLineWithYellow($"Периметр: {perimeter}");
		}

		#region Methods for colored text writing

		static void WriteLineWithColor(string message, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		static void WriteLineWithRed(string message)
		{
			WriteLineWithColor(message, ConsoleColor.Red);
		}

		static void WriteLineWithGreen(string message)
		{
			WriteLineWithColor(message, ConsoleColor.Green);
		}

		static void WriteLineWithYellow(string message)
		{
			WriteLineWithColor(message, ConsoleColor.Yellow);
		}

		#endregion

	}
}
