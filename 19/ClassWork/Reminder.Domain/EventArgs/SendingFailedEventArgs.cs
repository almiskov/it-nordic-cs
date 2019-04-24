using Reminder.Domain.Model;

namespace Reminder.Domain.EventArgs
{
	public class SendingFailedEventArgs : System.EventArgs
	{
		public SendReminderModel Reminder { get; set; }
		public System.Exception Exception { get; set; }

		public SendingFailedEventArgs(SendReminderModel reminder, System.Exception exception)
		{
			Reminder = reminder;
			Exception = exception;
		}
	}
}
