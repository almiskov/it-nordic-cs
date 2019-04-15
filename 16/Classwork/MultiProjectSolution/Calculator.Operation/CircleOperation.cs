using System;

namespace Calculator.Operation
{
	public class CircleOperation
	{
		public static double GetSurfaceArea(double radius)
		{
			return Math.PI * Math.Pow(radius, 2);
		}

		public static double GetPerimeter(double radius)
		{
			return 2 * Math.PI * radius;
		}
	}
}
