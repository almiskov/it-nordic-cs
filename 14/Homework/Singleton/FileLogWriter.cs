using System.IO;

namespace Singleton
{
	class FileLogWriter : AbstractLogWriter
	{
		public static string Path { get; set; } = "log.txt";

		private static FileLogWriter _instance;

		private FileLogWriter() { }

		public static FileLogWriter GetInstance()
		{
			if (_instance == null)
				_instance = new FileLogWriter();
			return _instance;
		}

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
