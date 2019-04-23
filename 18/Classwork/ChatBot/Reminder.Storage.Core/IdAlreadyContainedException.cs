using System;

namespace Reminder.Storage.Core
{
	public class IdAlreadyContainedException : Exception
	{
		public IdAlreadyContainedException(string message) : base(message) { }
	}
}
