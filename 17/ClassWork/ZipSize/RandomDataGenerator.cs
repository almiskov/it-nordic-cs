using System;

namespace ZipSize
{
	class RandomDataGenerator
	{
		public event EventHandler<RandomDataGeneratedEventArgs> RandomDataGenerated;
		public event EventHandler RandomDataGenerationDone;

		public byte[] GetRandomData(int dataSize, int bytesDoneToRaiseEvent)
		{
			byte[] randomDataArray = new byte[dataSize];

			for (int i = 0; i < randomDataArray.Length; i++)
			{
				randomDataArray[i] = (byte)(new Random().Next(256));

				if ((i + 1) % bytesDoneToRaiseEvent == 0)
				{
					OnRandomDataGenerated(this, new RandomDataGeneratedEventArgs(i + 1, dataSize));
				}
			}

			OnRandomDataGenerationDone(this, EventArgs.Empty);

			return randomDataArray;
		}

		protected virtual void OnRandomDataGenerated(object sender, RandomDataGeneratedEventArgs e)
		{
			RandomDataGenerated?.Invoke(sender, e);
		}

		protected virtual void OnRandomDataGenerationDone(object sender, EventArgs e)
		{
			RandomDataGenerationDone?.Invoke(sender, e);
		}
	}
}
