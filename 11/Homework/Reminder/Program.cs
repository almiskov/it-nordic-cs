using System;
using System.Threading;

namespace Reminder
{
	class Program
	{
		static void Main(string[] args)
		{
			ReminderItem reminder1 = new ReminderItem(
				DateTimeOffset.Parse("2019-04-05 07:00:00"),
				"Первый будильник");

			ReminderItem reminder2 = new ReminderItem(
				DateTimeOffset.Now + TimeSpan.FromSeconds(1),
				"Второй будильник");

			Thread.Sleep(2000);

			reminder1.WriteProperties();
			reminder2.WriteProperties();

			Console.ReadKey();
		}
	}
}
