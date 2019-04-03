using System;

namespace FlyingMachines
{
	public abstract class Flyer : IFlyingObject, IPropertiesWriter
	{
		public int MaxHeight { get; private set; }

		public int CurrentHeight { get; private set; }

		public Flyer(int maxHeight)
		{
			MaxHeight = maxHeight;
			CurrentHeight = 0;

			Console.WriteLine($"It's a {GetType().Name}, welcome aboard!");
		}

		public void TakeUpper(int delta)
		{
			if (delta <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(delta), "Delta must be positive value");
			}
			else if (CurrentHeight + delta > MaxHeight)
			{
				CurrentHeight = MaxHeight;
			}
			else
			{
				CurrentHeight = CurrentHeight + delta;
			}
		}

		public void TakeLower(int delta)
		{
			if (delta <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(delta), "Delta must be positive value");
			}
			else if (CurrentHeight - delta >= 0)
			{
				CurrentHeight = CurrentHeight - delta;
			}
			else if (CurrentHeight - delta < 0)
			{
				throw new InvalidOperationException("Crash!");
			}
		}

		public virtual void WriteAllProperties()
		{
			Console.WriteLine(
				$"Properties of {GetType().Name}:\n" +
				$"\t{nameof(CurrentHeight)}: {CurrentHeight}\n" +
				$"\t{nameof(MaxHeight)}: {MaxHeight}");
		}

		public abstract void WriteAllProperties2();
	}
}
