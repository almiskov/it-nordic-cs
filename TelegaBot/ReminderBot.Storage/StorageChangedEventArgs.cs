using System;
using ReminderBot.Reminder;

namespace ReminderBot.Storage
{
	public class StorageChangedEventArgs : EventArgs
	{
		public ReminderItem ReminderItem { get; private set; }

		public StorageChangedEventArgs(ReminderItem reminderItem)
		{
			ReminderItem = reminderItem;
		}
	}
}
