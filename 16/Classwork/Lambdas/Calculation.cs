using System;
using System.Collections.Generic;
using System.Text;

namespace Lambdas
{
	class Calculation
	{
		public int[] Array { get; set; }

		public Calculation(int[] array)
		{
			Array = array;
		}

		public double CalcSingleValue(Func<int[], double> func)
		{
			return func(Array);
		}
	}
}
