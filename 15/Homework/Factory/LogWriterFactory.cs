namespace Factory
{
	class LogWriterFactory
	{
		private static LogWriterFactory _instance;

		private LogWriterFactory() { }

		public static LogWriterFactory GetFactory()
		{
			if (_instance == null)
				_instance = new LogWriterFactory();
			return _instance;
		}

		public T GetLogWriter<T>() where T: ILogWriter, new()
		{
			return new T();
		}
	}
}
