using System;
using System.Collections.Generic;

namespace FlyingMachines
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Flyer> flyers = new List<Flyer>
				{
					new Plane(1000, 5),
					new Helicopter(1500, 3),
					new Helicopter(3000, 6),
					new Plane(1200, 6),
				};

			foreach (var flyer in flyers)
			{
				if (flyer != null)
				{
					Console.WriteLine(flyer.GetType().Name);

					if(flyer is IPlane)
					{
						Console.WriteLine((flyer as IPlane).EnginesCount);
					}

					if (flyer is IHelicopter)
					{
						Console.WriteLine((flyer as IHelicopter).BladesCount);
					}
				}
			}
		}
	}
}
