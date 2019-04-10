namespace LogWriting
{
	class MultipleLogWriter : AbstractLogWriter
	{
		private readonly ILogWriter[] _logWriters;

		public MultipleLogWriter(params ILogWriter[] logWriters)
		{
			_logWriters = logWriters;
		}

		protected override void Log(MessageType messageType, string message)
		{
			switch (messageType) // тут всё-таки можно обернуть всю эту штуку в цикл, а не в каждом кейсе делать цикл
			{
				case MessageType.Error:
					for (int i = 0; i < _logWriters.Length; i++)
						_logWriters[i].LogError(message);
					break;
				case MessageType.Info:
					for (int i = 0; i < _logWriters.Length; i++)
						_logWriters[i].LogInfo(message);
					break;
				case MessageType.Warning:
					for (int i = 0; i < _logWriters.Length; i++)
						_logWriters[i].LogWarning(message);
					break;
			}
		}
	}
}
