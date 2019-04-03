using System;

namespace FlyingMachines
{
	public class Helicopter : Flyer, IFlyingObject, IPropertiesWriter, IHelicopter
	{
		public byte BladesCount { get; private set; }

		public Helicopter(int maxHeight, byte bladesCount) : base(maxHeight)
		{
			BladesCount = bladesCount;
		}

		public override void WriteAllProperties()
		{
			base.WriteAllProperties();
			Console.WriteLine(
				$"\t{nameof(BladesCount)}: {BladesCount}");
		}

		public override void WriteAllProperties2()
		{
			Console.WriteLine(
				$"Properties of {GetType().Name}:\n" +
				$"\t{nameof(CurrentHeight)}: {CurrentHeight}\n" +
				$"\t{nameof(MaxHeight)}: {MaxHeight}\n" +
				$"\t{nameof(BladesCount)}: {BladesCount}");
		}
	}
}
