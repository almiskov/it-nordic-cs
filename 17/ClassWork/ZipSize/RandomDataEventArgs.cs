using System;

namespace ZipSize
{
	class RandomDataGeneratedEventArgs : EventArgs
	{
		public int BytesDone { get; set; }
		public int TotalBytes { get; set; }

		public RandomDataGeneratedEventArgs(int bytesDone, int totalBytes)
		{
			BytesDone = bytesDone;
			TotalBytes = totalBytes;
		}
	}
}
