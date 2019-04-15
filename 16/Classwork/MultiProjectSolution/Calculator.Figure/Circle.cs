using System;

namespace Calculator.Figure
{
	public class Circle
	{
		private double _radius;

		public Circle(double radius)
		{
			_radius = radius;
		}

		public double Calculate(Func<double, double> func)
		{
			return func(_radius);
		}
	}
}
