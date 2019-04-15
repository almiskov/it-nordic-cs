using System;
using Calculator.Figure;
using Calculator.Operation;
using Newtonsoft.Json;

namespace ConsoleAppNetCore
{
	class Program
	{
		static void Main(string[] args)
		{
			//Circle c = new Circle(1);

			//double perimeter = c.Calculate(CircleOperation.GetPerimeter);
			//double surface = c.Calculate(CircleOperation.GetSurfaceArea);

			//Console.WriteLine($"Perimeter is {perimeter}");
			//Console.WriteLine($"Surface is {surface}");

			//Rectangle r = new Rectangle(11, 22);
			//double p = r.Calculate(RectangleOperation.GetPerimeter);
			//double sq = r.Calculate(RectangleOperation.GetSurfaceArea);

			//Console.WriteLine($"Perimeter is {p}");
			//Console.WriteLine($"Surface is {sq}");

			var a = new Person
			{
				Name = "Alex",
				Age = 29
			};


			string packedJson = JsonConvert.SerializeObject(a);

			Console.WriteLine(packedJson);


			var newObject = JsonConvert.DeserializeObject<Person>(packedJson);
		}
	}

	public class Person
	{
		public string Name { get; set; }
		public int Age { get; set; }
	}
}
