using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Figure
{
	public class Rectangle
	{
		private double _height;
		private double _width;

		public Rectangle(double height, double width)
		{
			_height = height;
			_width = width;
		}

		public double Calculate(Func<double, double, double> func)
		{
			return func(_height, _width);
		}
	}
}
