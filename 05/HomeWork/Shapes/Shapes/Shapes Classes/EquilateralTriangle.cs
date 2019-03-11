using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
	class EquilateralTriangle : AbstractShape
	{
		private double side;

		public EquilateralTriangle(double side)
		{
			this.side = side;
		}

		public override double SurfaceArea
		{
			get
			{
				return Math.Round(Math.Pow(side, 2) * Math.Sqrt(3) / 4, roundingPrecision, MidpointRounding.AwayFromZero);
			}
		}

		public override double Perimeter
		{
			get
			{
				return Math.Round(side * 3, roundingPrecision, MidpointRounding.AwayFromZero);
			}
		}
	}
}
