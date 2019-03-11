using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
	public class App
	{
		enum Shape
		{
			Circle,
			Rectangle,
			EquilateralTriangle
		}

		private readonly AppIO appIO;

		public App(ConsoleWriter writer)
		{
			appIO = new AppIO(writer);
		}

		public void Run()
		{
			string[] namesArray = Enum.GetNames(typeof(Shape));
			string[] namesArrayRu = GetRuNames();

			appIO.WriteTitle(namesArrayRu);
			int choosedNumberOfShape = appIO.ReadShapeNumber(namesArray.Length);
			Shape choosedShape = GetShapeByItsNumber(choosedNumberOfShape, namesArray);

			switch (choosedShape)
			{
				case Shape.Circle:
					ProcessCircle();
					break;
				case Shape.Rectangle:
					ProcessRectangle();
					break;
				case Shape.EquilateralTriangle:
					ProcessEquilateralTriangle();
					break;
			}
		}

		private Shape GetShapeByItsNumber(int choosedNumberOfShape, string[] namesArray)
		{
			return (Shape)Enum.Parse(typeof(Shape), namesArray[choosedNumberOfShape], true);
		}

		private void ProcessCircle()
		{
			appIO.WriteParameterRequest("Введите диаметр круга");
			double diameter = appIO.ReadParameter();
			var circle = new Circle(diameter);
			appIO.WriteResult(circle.SurfaceArea, circle.Perimeter);
		}

		private void ProcessEquilateralTriangle()
		{
			appIO.WriteParameterRequest("Введите сторону равностороннего треугольника");
			double side = appIO.ReadParameter();
			var triangle = new EquilateralTriangle(side);
			appIO.WriteResult(triangle.SurfaceArea, triangle.Perimeter);
		}

		private void ProcessRectangle()
		{
			appIO.WriteParameterRequest("Введите высоту прямоугольника");
			double height = appIO.ReadParameter();
			appIO.WriteParameterRequest("Введите ширину прямоугольника");
			double width = appIO.ReadParameter();
			var rectangle = new Rectangle(height, width);
			appIO.WriteResult(rectangle.SurfaceArea, rectangle.Perimeter);
		}

		private string[] GetRuNames()
		{
			Dictionary<Shape, string> shapeNamesPairs = new Dictionary<Shape, string>
			{
				{ Shape.Circle, "Круг" },
				{ Shape.Rectangle, "Прямоугольник" },
				{ Shape.EquilateralTriangle, "Равносторонний треугольник" }
			};

			string[] ruNames = new string[shapeNamesPairs.Count];
			shapeNamesPairs.Values.CopyTo(ruNames, 0);

			return ruNames;
		}
	}
}
