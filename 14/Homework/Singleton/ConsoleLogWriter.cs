using System;

namespace Singleton
{
	class ConsoleLogWriter : AbstractLogWriter
	{
		private static ConsoleLogWriter _instance;

		private ConsoleLogWriter() { }

		public static ConsoleLogWriter GetInstance()
		{
			if (_instance == null)
				_instance = new ConsoleLogWriter();
			return _instance;
		}

		protected override void Log(MessageType messageType, string message)
		{
			SetConsoleForegroungColor(messageType);
			Console.WriteLine(GetLogRecord(messageType, message));
			Console.ResetColor();
		}

		private void SetConsoleForegroungColor(MessageType messageType)
		{
			ConsoleColor consoleForegroundColor = Console.ForegroundColor;

			switch (messageType)
			{
				case MessageType.Error:
					consoleForegroundColor = ConsoleColor.Red;
					break;
				case MessageType.Info:
					consoleForegroundColor = ConsoleColor.Blue;
					break;
				case MessageType.Warning:
					consoleForegroundColor = ConsoleColor.Yellow;
					break;
			}

			Console.ForegroundColor = consoleForegroundColor;
		}
	}
}
