using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Domain.Model;
using System;

namespace Reminder.Domain.Tests
{
	[TestClass]
	public class SendReminderModelTests
	{
		[TestMethod]
		public void Check_That_All_Propeties_Set()
		{
			var expectedId = Guid.NewGuid();
			var expectedMessage = "Message";
			var expectedContactId = "+71234567890";

			var sendReminderModel = new SendReminderModel()
			{
				ContactId = expectedContactId,
				Id = expectedId,
				Message = expectedMessage
			};

			Assert.AreEqual(expectedId, sendReminderModel.Id);
			Assert.AreEqual(expectedMessage, sendReminderModel.Message);
			Assert.AreEqual(expectedContactId, sendReminderModel.ContactId);
		}
	}
}
