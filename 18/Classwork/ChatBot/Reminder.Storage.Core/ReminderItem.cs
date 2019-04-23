﻿using System;

namespace Reminder.Storage.Core
{
	public class ReminderItem
	{
		public Guid Id { get; set; }
		public DateTimeOffset Date { get; set; }
		public string Message { get; set; }
		public string ContactId { get; private set; }
		public TimeSpan TimeToSend => Date - DateTimeOffset.UtcNow;
		public ReminderItemStatus Status { get; set; }

		public ReminderItem(Guid id, DateTimeOffset date, string message, string contactId)
		{
			Id = id;
			Date = date;
			Message = message;
			ContactId = contactId;
		}
	}
}