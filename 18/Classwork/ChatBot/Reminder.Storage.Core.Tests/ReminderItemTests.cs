using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reminder.Storage.Core.Tests
{
	[TestClass]
	public class ReminderItemTests
	{
		[TestMethod]
		public void Constructor_Validly_Sets_Id_Property()
		{
			// Preparing
			Guid expected = new Guid("3F2C6742-3ACB-45D0-9C77-0BDD0BC96CC2");

			// Running
			var reminderItem = new ReminderItem(
				expected,
				DateTimeOffset.MinValue,
				null,
				null);

			// Checking
			Assert.AreEqual(expected, reminderItem.Id);
		}

		[TestMethod]
		public void Constructor_Validly_Sets_Date_Property()
		{
			// Preparing
			DateTimeOffset expected = DateTimeOffset.Now;

			// Running
			var reminderItem = new ReminderItem(
				Guid.Empty,
				expected,
				null,
				null);

			// Checking
			Assert.AreEqual(expected, reminderItem.Date);
		}

		[TestMethod]
		public void TimeToSend_Is_in_500ms_Range()
		{
			// Preparing
			var reminderItem = new ReminderItem(
				Guid.Empty,
				DateTimeOffset.Now + TimeSpan.FromMilliseconds(100),
				null,
				null);

			// Running
			var actual = reminderItem.TimeToSend;

			// Checking
			Assert.IsTrue(actual < TimeSpan.FromMilliseconds(100) && actual > TimeSpan.Zero);
		}

		[TestMethod]
		public void TimeToSend_Is_Less_Than_Zero_For_Date_in_the_past()
		{
			// Preparing
			var reminderItem = new ReminderItem(
				Guid.Empty,
				DateTimeOffset.Now - TimeSpan.FromHours(1),
				null,
				null);

			// Running
			var actual = reminderItem.TimeToSend;

			// Checking
			Assert.IsTrue(actual < TimeSpan.Zero);
		}

	}
}
