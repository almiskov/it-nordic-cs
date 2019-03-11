using System;

namespace Shapes
{
	class Program
	{
		static void Main(string[] args)
		{
			var writer = new ConsoleWriter();
			var app = new App(writer);

			try
			{
				app.Run();
			}
			catch (Exception e)
			{
				writer.WriteLineRed($"{e.GetType()}: {e.Message}");
				throw;
			}

			Console.ReadLine();
		}
	}
}
