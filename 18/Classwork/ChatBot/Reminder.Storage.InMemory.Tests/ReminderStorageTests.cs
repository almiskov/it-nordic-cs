using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using System;
using System.Collections.Generic;

namespace Reminder.Storage.InMemory.Tests
{
	[TestClass]
	public class ReminderStorageTests
	{
		[TestMethod]
		public void Constructor_Initializes_Inner_Dictionary()
		{
			// Preparing
			int expected = 0;

			// Running
			ReminderStorage storage = new ReminderStorage();

			int actual = storage.Count;

			// Checking
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Add_Method_Adds_ReminderItem_Into_Dictionary()
		{
			// Preparing
			int expected = 1;

			ReminderStorage storage = new ReminderStorage();

			ReminderItem item = new ReminderItem(
				Guid.NewGuid(),
				DateTimeOffset.Now,
				null,
				null);

			// Running
			storage.Add(item);

			int actual = storage.Count;

			// Checking
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Add_Method_Throws_Exception_If_Already_Contains_Key()
		{
			// Preparing
			ReminderStorage storage = new ReminderStorage();
			ReminderItem item = new ReminderItem(
				Guid.NewGuid(),
				DateTimeOffset.Now,
				null,
				null);

			storage.Add(item);

			// Checking
			Assert.ThrowsException<IdAlreadyContainedException>(() => storage.Add(item));
		}

		[TestMethod]
		public void Get_Method_Returns_ReminderItem_Asked_For()
		{
			// Preparing
			ReminderStorage storage = new ReminderStorage();
			Guid id = Guid.NewGuid();

			ReminderItem expected = new ReminderItem(
				id,
				DateTimeOffset.Now,
				null,
				null);

			// Running
			storage.Add(expected);

			ReminderItem actual = storage.Get(id);

			// Checking
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Get_Method_Returns_Null_If_Not_Contains_Item()
		{
			// Preparing
			ReminderStorage storage = new ReminderStorage();
			Guid id = Guid.NewGuid();

			// Running
			ReminderItem expectedToBeNull = storage.Get(id);

			// Checking
			Assert.IsNull(expectedToBeNull);
		}

		[TestMethod]
		public void Update_Method_Updates_Contained_Item()
		{
			// Preparing
			ReminderStorage storage = new ReminderStorage();
			Guid id = Guid.NewGuid();

			ReminderItem expectedToBeUpdated = new ReminderItem(
				id,
				DateTimeOffset.Now,
				null,
				null);

			storage.Add(expectedToBeUpdated);

			// Running
			expectedToBeUpdated.Message = "Get Up!";

			storage.Update(expectedToBeUpdated);

			// Checking
			Assert.AreEqual(expectedToBeUpdated, storage.Get(id));
		}

		[TestMethod]
		public void Update_Method_Throws_Exception_If_Storage_Doesnt_Contain_Item()
		{
			// Preparing
			ReminderStorage storage = new ReminderStorage();
			Guid id = Guid.NewGuid();

			ReminderItem expectedToBeUpdated = new ReminderItem(
				id,
				DateTimeOffset.Now,
				null,
				null);

			// Running
			expectedToBeUpdated.Message = "Get Up!";

			// Checking
			Assert.ThrowsException<KeyNotFoundException>(() => storage.Update(expectedToBeUpdated));
		}
	}
}
