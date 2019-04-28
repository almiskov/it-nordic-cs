using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Domain.Model;
using Reminder.Storage.InMemory;


namespace Reminder.Domain.Tests
{
	[TestClass]
	public class ReminderDomainTests
	{
		[TestMethod]
		public void Check_That_Reminder_Calls_Internal_Delegate()
		{
			var reminderStorage = new ReminderStorage();
			var reminderDomain = new ReminderDomain(reminderStorage);

			bool delegateWasCalled = false;

			reminderDomain.SendReminder += r =>
			{
				delegateWasCalled = true;
			};

			reminderDomain.Add(
				new AddReminderModel()
				{
					Date = DateTimeOffset.Now
				});

			reminderDomain.Run();

			Thread.Sleep(2500);

			Assert.IsTrue(delegateWasCalled);
		}

		[TestMethod]
		public void Check_That_On_SendReminder_SendingSucceded_Event_Raised()
		{
			var reminderStorage = new ReminderStorage();
			var reminderDomain = new ReminderDomain(reminderStorage);

			bool eventHandlerCalled = false;

			reminderDomain.SendingSucceded += (s, e) =>
			{
				eventHandlerCalled = true;
			};

			reminderDomain.Add(
				new AddReminderModel()
				{
					Date = DateTimeOffset.Now
				});

			reminderDomain.Run();

			Thread.Sleep(2500);

			Assert.IsTrue(eventHandlerCalled);
		}

		[TestMethod]
		public void Check_That_On_SendReminder_Exception_SendingFailed_Event_Raised()
		{
			var reminderStorage = new ReminderStorage();
			var reminderDomain = new ReminderDomain(reminderStorage);

			reminderDomain.SendReminder += (reminder) =>
			{
				throw new Exception();
			};

			bool eventHandlerCalled = false;
			reminderDomain.SendingFailed += (s, e) =>
			{
				eventHandlerCalled = true;
			};

			reminderDomain.Add(
				new AddReminderModel()
				{
					Date = DateTimeOffset.Now
				});

			reminderDomain.Run();

			Thread.Sleep(2000);

			Assert.IsTrue(eventHandlerCalled);
		}

		[TestMethod]
		public void Check_That_Add_Method_Adds_AddReminderModel_Into_Storage()
		{
			var reminderStorage = new ReminderStorage();
			var reminderDomain = new ReminderDomain(reminderStorage);

			reminderDomain.Add(
				new AddReminderModel()
				{
					Date = DateTimeOffset.Now
				});

			Assert.AreEqual(1, reminderStorage.Count);
		}

		[TestMethod]
		public void Check_That_Added_ReminderItem_Has_Awaiting_Status()
		{
			var reminderStorage = new ReminderStorage();
			var reminderDomain = new ReminderDomain(reminderStorage);
			var reminderModel = new AddReminderModel()
			{
				Date = DateTimeOffset.Now + TimeSpan.FromMilliseconds(1000)
			};

			reminderDomain.Add(reminderModel);

			var status = reminderStorage.Get(1)[0].Status;

			Assert.AreEqual(
				Storage.Core.ReminderItemStatus.Awaiting,
				status);
		}

		[TestMethod]
		public void Check_That_CheckAwaitingReminders_Method_Turns_Awaiting_Status_Into_Ready()
		{
			var reminderStorage = new ReminderStorage();
			var reminderDomain = new ReminderDomain(reminderStorage);
			var reminderModel = new AddReminderModel()
			{
				Date = DateTimeOffset.Now
			};

			reminderDomain.Add(reminderModel);

			reminderDomain.CheckAwaitingReminders(null);

			var status = reminderStorage.Get(1)[0].Status;

			Assert.AreEqual(
				Storage.Core.ReminderItemStatus.Ready,
				status);
		}

		[TestMethod]
		public void Check_That_SendReadyReminders_Method_Turns_Ready_Status_Into_Sent_If_Sending_Succeded()
		{
			var reminderStorage = new ReminderStorage();
			var reminderDomain = new ReminderDomain(reminderStorage);
			var reminderModel = new AddReminderModel()
			{
				Date = DateTimeOffset.Now
			};

			reminderDomain.Add(reminderModel);

			reminderDomain.CheckAwaitingReminders(null);
			reminderDomain.SendReadyReminders(null);

			var status = reminderStorage.Get(1)[0].Status;

			Assert.AreEqual(
				Storage.Core.ReminderItemStatus.Sent,
				status);
		}

		[TestMethod]
		public void Check_That_SendReadyReminders_Method_Turns_Ready_Status_Into_Failed_If_Sending_Failed()
		{
			var reminderStorage = new ReminderStorage();
			var reminderDomain = new ReminderDomain(reminderStorage);
			var reminderModel = new AddReminderModel()
			{
				Date = DateTimeOffset.Now
			};

			reminderDomain.SendReminder += r =>
			{
				throw new Exception();
			};

			reminderDomain.Add(reminderModel);

			reminderDomain.CheckAwaitingReminders(null);
			reminderDomain.SendReadyReminders(null);

			var status = reminderStorage.Get(1)[0].Status;

			Assert.AreEqual(
				Storage.Core.ReminderItemStatus.Failed,
				status);
		}


	}
}
