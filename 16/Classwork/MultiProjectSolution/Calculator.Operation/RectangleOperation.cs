using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operation
{
	public class RectangleOperation
	{
		public static double GetSurfaceArea(double height, double width)
		{
			return height * width;
		}

		public static double GetPerimeter(double height, double width)
		{
			return 2 * (height + width);
		}
	}
}
