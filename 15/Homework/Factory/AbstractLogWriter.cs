using System;

namespace Factory
{
	abstract class AbstractLogWriter : ILogWriter
	{
		private readonly string _logRecordFormat = "{0:yyyy-MM-ddTHH:mm:sszzz}\t{1}\t\t{2}";

		protected string GetLogRecord(MessageType messageType, string message)
		{
			return string.Format(
				_logRecordFormat,
				DateTimeOffset.Now,
				messageType,
				message);
		}

		public void LogError(string message)
		{
			Log(MessageType.Error, message);
		}

		public void LogInfo(string message)
		{
			Log(MessageType.Info, message);
		}

		public void LogWarning(string message)
		{
			Log(MessageType.Warning, message);
		}

		protected abstract void Log(MessageType messageType, string message);
	}
}

