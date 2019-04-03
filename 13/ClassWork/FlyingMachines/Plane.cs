using System;

namespace FlyingMachines
{
	public class Plane : Flyer, IFlyingObject, IPropertiesWriter, IPlane
	{
		public byte EnginesCount { get; private set; }

		public Plane(int maxHeight, byte enginesCount) : base(maxHeight)
		{
			EnginesCount = enginesCount;
		}

		public override void WriteAllProperties()
		{
			base.WriteAllProperties();
			Console.WriteLine(
				$"\t{nameof(EnginesCount)}: {EnginesCount}");
		}

		public override void WriteAllProperties2()
		{
			Console.WriteLine(
				$"Properties of {GetType().Name}:\n" +
				$"\t{nameof(CurrentHeight)}: {CurrentHeight}\n" +
				$"\t{nameof(MaxHeight)}: {MaxHeight}\n" +
				$"\t{nameof(EnginesCount)}: {EnginesCount}");
		}
	}
}
