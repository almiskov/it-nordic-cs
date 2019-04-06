namespace LogWriting
{
	enum MessageType
	{
		Info,
		Warning,
		Error
	}

	// Добавляя новый тип сообщения, необходимо добавить соответствующий метод в ILogWriter, 
	// а также добавить его обработку в класс MultipleLogWriter, метод Log()
	// Также для выделения его определённым цветом необходимо внести изменения в метод
	// SetConsoleForegroundColor() класса ConsoleLogWriter
}
