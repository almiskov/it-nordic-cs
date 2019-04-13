using System;
using System.IO;

namespace LogWriting
{
	class FileLogWriter : AbstractLogWriter
	{
		private string _path;

		public FileLogWriter(string path = "log.txt")
		{
			_path = path;
		}

		protected override void Log(MessageType messageType, string message)
		{
			using (StreamWriter sw = new StreamWriter(_path, true))
			{
				sw.WriteLine($"{DateTimeOffset.Now:yyyy-MM-ddTHH:mm:sszzz}\t{messageType}\t\t{message}");
				sw.Flush();
			}
		}
	}
}
