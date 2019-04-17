using System;
using System.IO;

namespace ZipSize
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = "data";

			RandomDataGenerator rdg = new RandomDataGenerator();

			rdg.RandomDataGenerated += (sender, e) => Console.WriteLine($"Generated {e.BytesDone} from {e.TotalBytes} bytes");
			rdg.RandomDataGenerationDone += (sender, e) => Console.WriteLine("Generation done!");

			byte[] bytes = rdg.GetRandomData(1000000, 200000);

			//Console.WriteLine(Convert.ToBase64String(bytes));
			File.WriteAllBytes(path, bytes);
		}
	}
}
