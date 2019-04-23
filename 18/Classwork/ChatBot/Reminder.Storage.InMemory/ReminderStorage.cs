using System;
using System.Collections.Generic;
using Reminder.Storage.Core;

namespace Reminder.Storage.InMemory
{
	public class ReminderStorage : IReminderStorage
	{
		private Dictionary<Guid, ReminderItem> _storage;

		public int Count => _storage.Count;
		
		public ReminderStorage()
		{
			_storage = new Dictionary<Guid, ReminderItem>();
		}

		public void Add(ReminderItem reminderItem)
		{
			if (_storage.ContainsKey(reminderItem.Id))
				throw new IdAlreadyContainedException("Inner dictionary already contains key");
			else
				_storage.Add(reminderItem.Id, reminderItem);
		}

		public ReminderItem Get(Guid id)
		{
			return _storage.ContainsKey(id)
				? _storage[id]
				: null;
		}

		public List<ReminderItem> GetList(IEnumerable<ReminderItemStatus> statuses, int startPosition, int count)
		{
			/// TODO: понять, каким образом должен работать этот метод с такими входными параметрами,
			/// зачем туда передавать несколько статусов,
			/// и где у Dictionary start index, и что вообще может им считаться

			//ReminderItem[] reminders = new ReminderItem[count];
			//_storage.Values.CopyTo(reminders, 0);

			throw new NotImplementedException();
		}

		public void Update(ReminderItem reminderItem)
		{
			if(_storage.ContainsKey(reminderItem.Id))
				_storage[reminderItem.Id] = reminderItem;
			else
				throw new KeyNotFoundException("Reminder not found");
		}
	}
}
