using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Domain.Model;
using System;

namespace Reminder.Domain.Tests
{
	[TestClass]
	public class AddReminderModelTests
	{
		[TestMethod]
		public void Check_That_All_Propeties_Set()
		{
			string expectedContactId = "+71234567890";
			DateTimeOffset expectedDate = DateTimeOffset.Now;
			string expectedMessage = "Hello";

			var addReminderModel = new AddReminderModel()
			{
				ContactId = expectedContactId,
				Date = expectedDate,
				Message = expectedMessage
			};

			Assert.AreEqual(expectedContactId, addReminderModel.ContactId);
			Assert.AreEqual(expectedDate, addReminderModel.Date);
			Assert.AreEqual(expectedMessage, addReminderModel.Message);
		}
	}
}
