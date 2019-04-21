using System;
using System.Collections.Generic;
using ReminderBot.Reminder;

namespace ReminderBot.Storage
{
	interface IReminderStorage
	{
		int Count { get; }
		void Add(ReminderItem reminderItem);
		void Update(ReminderItem reminderItem, params object[] reminderParams);
		bool Contains(ReminderItem reminderItem);
		List<ReminderItem> GetReminderItems(Predicate<ReminderItem> predicate);
	}
}
