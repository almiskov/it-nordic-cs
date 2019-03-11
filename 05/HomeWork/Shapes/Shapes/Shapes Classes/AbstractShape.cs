using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
	public abstract class AbstractShape
	{
		protected int roundingPrecision = 3;
		public abstract double SurfaceArea { get; }
		public abstract double Perimeter { get; }
	}
}
