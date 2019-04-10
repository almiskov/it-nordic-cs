using System;

namespace Delegates
{
	class Program
	{
		static void Main(string[] args)
		{
			Circle c = new Circle(1.5f);

			Console.WriteLine(c.Calculate(Calculations.CirclePerimeter));
			Console.WriteLine(c.Calculate(Calculations.CircleSurfaceArea));
		}
	}
}
