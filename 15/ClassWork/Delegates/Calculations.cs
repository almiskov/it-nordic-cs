using System;

namespace Delegates
{
	public static class Calculations
	{
		public static double CirclePerimeter(double radius)
		{
			return 2 * Math.PI * radius;
		}

		public static double CircleSurfaceArea(double radius)
		{
			return Math.PI * Math.Pow(radius, 2);
		}
	}
}
