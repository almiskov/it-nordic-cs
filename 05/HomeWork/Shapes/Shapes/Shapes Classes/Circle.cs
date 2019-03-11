using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
	public class Circle : AbstractShape
	{
		private double diameter;

		public Circle(double diameter)
		{
			this.diameter = diameter;
		}

		public override double SurfaceArea
		{
			get
			{
				return Math.Round(Math.PI * Math.Pow(diameter, 2) / 4, roundingPrecision, MidpointRounding.AwayFromZero);
			}
		}

		public override double Perimeter
		{
			get
			{
				return Math.Round(Math.PI * diameter, roundingPrecision, MidpointRounding.AwayFromZero);
			}
		}
	}
}
