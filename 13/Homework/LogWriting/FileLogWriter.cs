using System;
using System.IO;

namespace LogWriting
{
	class FileLogWriter : AbstractLogWriter
	{
		protected override void Log(MessageType messageType, string message)
		{
			string path = "log.txt";

			using (StreamWriter sw = new StreamWriter(path, true))
			{
				sw.WriteLine($"{DateTimeOffset.Now:yyyy-MM-ddTHH:mm:sszzz}\t{messageType}\t\t{message}");
				sw.Flush();
			}
		}
	}
}
