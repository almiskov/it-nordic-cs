namespace Singleton
{
	class Program
	{
		static void Main(string[] args)
		{
			FileLogWriter flw = FileLogWriter.GetInstance();
			ConsoleLogWriter clw = ConsoleLogWriter.GetInstance();

			MultipleLogWriter mlw = MultipleLogWriter.GetInstance();
			mlw.Add(flw);
			mlw.Add(clw);

			mlw.LogWarning("Warning");
			mlw.LogError("Error");

			mlw.Remove(clw);

			FileLogWriter.Path = "anotherLog.txt";

			mlw.LogInfo("Another info");
		}
	}
}
