﻿namespace LogWriting
{
	abstract class AbstractLogWriter : ILogWriter
	{
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

