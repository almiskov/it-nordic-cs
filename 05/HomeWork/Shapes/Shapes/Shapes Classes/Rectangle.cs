using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
	public class Rectangle : AbstractShape
	{
		private double height;
		private double width;

		public Rectangle(double height, double width)
		{
			this.height = height;
			this.width = width;
		}

		public override double SurfaceArea
		{
			get
			{
				return Math.Round(height * width, roundingPrecision, MidpointRounding.AwayFromZero);
			}
		}

		public override double Perimeter
		{
			get
			{
				return Math.Round(2 * (height + width), roundingPrecision, MidpointRounding.AwayFromZero);
			}
		}
	}
}
