using System.IO;

namespace Factory
{
	class FileLogWriter : AbstractLogWriter
	{
		public string Path { get; set; } = "log.txt";

		protected override void Log(MessageType messageType, string message)
		{
			using (StreamWriter sw = new StreamWriter(Path, true))
			{
				sw.WriteLine(GetLogRecord(messageType, message));
				sw.Flush();
			}
		}
	}
}
