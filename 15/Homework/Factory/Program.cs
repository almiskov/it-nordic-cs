namespace Factory
{
	class Program
	{
		static void Main(string[] args)
		{
			var logWriterFactory = LogWriterFactory.GetFactory();

			var clw = logWriterFactory.GetLogWriter<ConsoleLogWriter>();
			var flw = logWriterFactory.GetLogWriter<FileLogWriter>();
			var mlw = logWriterFactory.GetLogWriter<MultipleLogWriter>();

			mlw.Add(flw);
			mlw.Add(clw);

			mlw.LogError("Input error");
			mlw.LogInfo("WOW!");
			mlw.LogWarning("Very warning"); 
		}
	}
}
