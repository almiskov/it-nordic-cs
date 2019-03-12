using System;

namespace Savings_v2._0
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleWriter writer = new ConsoleWriter();

			App application = new App(writer);
			application.Run();

			Console.ReadLine();
		}
	}
}
