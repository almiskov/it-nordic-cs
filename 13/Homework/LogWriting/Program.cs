using System.Threading;

namespace LogWriting
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleLogWriter clw = new ConsoleLogWriter();
			FileLogWriter flw = new FileLogWriter();

			MultipleLogWriter mlw = new MultipleLogWriter(clw, flw);

			mlw.LogError("Some fatal error");
			Thread.Sleep(1000);
			mlw.LogInfo("Some interesting info");
			Thread.Sleep(1000);
			mlw.LogWarning("Some irritating warning");
		}
	}
}
