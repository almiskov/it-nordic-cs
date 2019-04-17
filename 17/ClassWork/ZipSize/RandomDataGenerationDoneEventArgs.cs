using System;
using System.Collections.Generic;
using System.Text;

namespace ZipSize
{
	class RandomDataGenerationDoneEventArgs : EventArgs
	{
		public byte[] RandomData { get; set; }

		public RandomDataGenerationDoneEventArgs(byte[] randomData)
		{
			RandomData = randomData;
		}
	}
}
