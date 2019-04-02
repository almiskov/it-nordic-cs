using System;
using System.Collections.Generic;
using System.Threading;

namespace Reminder
{
	class Program
	{
		static void Main(string[] args)
		{
			List<ReminderItem> reminders = new List<ReminderItem>
			{
				new ReminderItem(DateTimeOffset.Parse("2019-04-04 07:00:00"), "Первый будильник"),
				new PhoneReminderItem(DateTimeOffset.Now, "Второй будильник", "+79060871207"),
				new ChatReminderItem(DateTimeOffset.Parse("2019-04-05 08:00:00"), "Третий будильник", "Котики", "Кот-бегемот"),
				new ReminderItem(DateTimeOffset.Parse("2019-04-06 09:00:00"), "Четвёртый будильник"),
			};

			Thread.Sleep(1000);

			for(int i = 0; i < reminders.Count; i++)
			{
				Console.Write(i + ": ");
				reminders[i].WriteProperties();
				Console.WriteLine();
			}
		}
	}
}
