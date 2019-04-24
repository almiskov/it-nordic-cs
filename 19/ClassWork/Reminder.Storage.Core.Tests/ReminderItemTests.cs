using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reminder.Storage.Core.Tests
{
	[TestClass]
	public class ReminderItemTests
	{
		[TestMethod]
		public void Id_Is_Persistant()
		{
			var reminder = new ReminderItem
			{
				Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(1)),
				Message = "Test"
			};

			var actual = reminder.Id;
			var expected = reminder.Id;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Id_Is_Not_Default_Guid_Empty()
		{
			var reminder = new ReminderItem
			{
				Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(1)),
				Message = "Test"
			};

			var actual = reminder.Id;

			Assert.AreNotEqual(Guid.Empty, actual);
		}
	}
}
