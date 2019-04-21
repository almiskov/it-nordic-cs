using ReminderBot.Reminder;
using ReminderBot.Sender;
using ReminderBot.Storage;
using System;
using System.Threading;

namespace ReminderBot
{
	class App
	{
		private ReminderStorage _reminderStorage; // в конечном итоге его в этом классе быть не должно (сейчас только для теста)
		private ReminderSender _reminderSender;

		public App()
		{
			_reminderStorage = ReminderStorage.GetInstance();

			_reminderStorage.ItemAdded += (s, e) =>
			{
				Console.WriteLine(
					$"({DateTimeOffset.Now.DateTime.ToLongTimeString()}) " +
					$"Item added: {e.ReminderItem.Message} " +
					$"at {e.ReminderItem.ReminderDate.DateTime.ToLongTimeString()}");
			};

			_reminderSender = new ReminderSender();
		}

		public void Run()
		{
			//InsertTestDataIntoStorage();

			Console.WriteLine($"Now is {DateTimeOffset.Now.DateTime.ToLongTimeString()}");

			Thread t = new Thread(() =>
			{
				while (true)
				{
					Thread.Sleep(1000);
					_reminderSender.SendNext();
				}
			});

			t.Start();

			Thread.Sleep(5000);

			// Like runtime adding

			_reminderStorage.Add(new ReminderItem(
				TimeSpan.FromSeconds(10),
				"Blink!",
				"+79060871207"));

			_reminderStorage.Add(new ReminderItem(
				TimeSpan.FromSeconds(18),
				"Pat the cat!",
				"+79060871207"));

			Thread.Sleep(5000);

			_reminderStorage.Add(new ReminderItem(
				TimeSpan.FromSeconds(13),
				"Scratch!",
				"+79060871207"));

			Thread.Sleep(2000);

			_reminderStorage.Add(new ReminderItem(
				TimeSpan.FromSeconds(4),
				"Have a cup of tea!",
				"+79060871207"));
		}

		private void InsertTestDataIntoStorage()
		{
			#region Reminders creating

			var reminder0 = new ReminderItem(
				DateTimeOffset.Parse("2019-04-22 08:30"),
				"Wake Up!",
				"+79857045850");

			var reminder1 = new ReminderItem(
				DateTimeOffset.Parse("2019-04-22 08:40"),
				"Get Exercise!",
				"+79060871207");

			var reminder2 = new ReminderItem(
				TimeSpan.FromSeconds(2),
				"Yawn!",
				"+79060871207");

			var reminder3 = new ReminderItem(
				DateTimeOffset.Parse("2019-04-21 23:00"),
				"Go sleep!",
				"+79857045850");

			var reminder4 = new ReminderItem(
				TimeSpan.FromSeconds(5),
				"Fart!",
				"+79060871207");

			var reminder5 = new ReminderItem(
				TimeSpan.FromSeconds(5),
				"Get Rest!",
				"+79060871207");

			var reminder6 = new ReminderItem(
				TimeSpan.FromHours(1) + TimeSpan.FromMinutes(30),
				"Take a shower!",
				"+79857045850");

			#endregion

			#region Make some storage

			_reminderStorage.Add(reminder0);
			_reminderStorage.Add(reminder1);
			_reminderStorage.Add(reminder2);
			_reminderStorage.Add(reminder3);
			_reminderStorage.Add(reminder4);
			_reminderStorage.Add(reminder5);
			_reminderStorage.Add(reminder6);

			#endregion

		}
	}
}
