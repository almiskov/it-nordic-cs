using System;

namespace ReminderBot.Reminder
{
	public class ReminderItem
	{
		public DateTimeOffset CreationDate { get; }
		public DateTimeOffset ReminderDate { get; set; }
		public string Message { get; set; }
		public string ContactId { get; private set; }
		public bool IsSent { get; set; }

		public bool IsOutdated
		{
			get { return ReminderDate < DateTimeOffset.Now; }
		}

		private ReminderItem(string message, string contactId)
		{
			CreationDate = DateTimeOffset.Now;
			Message = message;
			ContactId = contactId;
		}

		public ReminderItem(DateTimeOffset reminderDate, string message, string contactId)
			: this(message, contactId)
		{
			ReminderDate = reminderDate;
		}

		public ReminderItem(TimeSpan fromNow, string message, string contactId)
			: this(message, contactId)
		{
			ReminderDate = DateTimeOffset.Now + fromNow;
		}

		public string GetFullPropertiesString()
		{
			return
				$"{nameof(CreationDate)}: {CreationDate}\n" +
				$"{nameof(ReminderDate)}: {ReminderDate}\n" +
				$"{nameof(Message)}: {Message}\n" +
				$"{nameof(ContactId)}: {ContactId}\n" +
				$"{nameof(IsOutdated)}: {IsOutdated}\n" +
				$"{nameof(IsSent)}: {IsSent}";
		}

		public string GetShortPropertiesString()
		{
			return
				$"Created at {CreationDate.DateTime.ToLongTimeString()} " +
				$"to {ReminderDate.DateTime.ToLongTimeString()} " +
				$"\"{Message}\" " +
				string.Format(IsOutdated ? "Outdated " : "Actual ") +
				string.Format(IsSent ? "Sent" : "Not sent");
		}

		public string GetShortInfo()
		{
			return
				$"It's {ReminderDate.DateTime.ToLongTimeString()}! " +
				$"\"{Message}\"";
		}
	}
}
