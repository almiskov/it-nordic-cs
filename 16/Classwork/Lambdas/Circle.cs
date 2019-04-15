using System;

namespace Lambdas
{
	class Circle
	{
		private double _radius;

		public Circle(double radius)
		{
			_radius = radius;
		}

		public double Calculate(Func<double, double> calculate)
		{
			return calculate(_radius);
		}

	}
}
