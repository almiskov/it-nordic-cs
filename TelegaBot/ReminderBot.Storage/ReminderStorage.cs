using System;
using System.Collections;
using System.Collections.Generic;
using ReminderBot.Reminder;

namespace ReminderBot.Storage
{
	public class ReminderStorage : IReminderStorage, IEnumerable<ReminderItem>
	{
		#region Singleton implementation

		private static ReminderStorage _instance;

		private ReminderStorage()
		{
			_reminderList = new List<ReminderItem>();
		}

		public static ReminderStorage GetInstance()
		{
			if (_instance == null)
				_instance = new ReminderStorage();
			return _instance;
		}

		#endregion

		private List<ReminderItem> _reminderList;

		public int Count => _reminderList.Count;

		public event EventHandler<StorageChangedEventArgs> ItemAdded;
		public event EventHandler<StorageChangedEventArgs> ItemUpdated;

		public void Add(ReminderItem reminderItem)
		{
			_reminderList.Add(reminderItem);
			OnItemAdded(reminderItem);
		}

		/// <summary>
		/// Updates the specified reminder item.
		/// </summary>
		/// <param name="reminderItem">The reminder item.</param>
		/// <param name="reminderParams">The reminder changeble parameters: DateTimeOffset ReminderDate, string Message, bool IsSent.</param>
		public void Update(ReminderItem reminderItem, params object[] reminderParams) // и вообще метод кривой, его надо переделать
		{
			// Если в reminderItem появятся изменяемые свойства одного типа, то лучше сделать как-нибудь по-другому
			foreach (object parameter in reminderParams)
			{
				if (parameter is DateTimeOffset)
					reminderItem.ReminderDate = (DateTimeOffset)parameter;
				if (parameter is string)
					reminderItem.Message = (string)parameter;
				if (parameter is bool)
					reminderItem.IsSent = (bool)parameter;
			}

			OnItemUpdated(reminderItem);
		}

		public bool Contains(ReminderItem reminderItem)
		{
			return _reminderList.Contains(reminderItem);
		}

		public List<ReminderItem> GetReminderItems(Predicate<ReminderItem> predicate)
		{
			return _reminderList.FindAll(predicate);
		}

		public IEnumerator<ReminderItem> GetEnumerator()
		{
			return _reminderList.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _reminderList.GetEnumerator();
		}

		private void OnItemAdded(ReminderItem reminderItem)
		{
			ItemAdded?.Invoke(this, new StorageChangedEventArgs(reminderItem));
		}
		private void OnItemUpdated(ReminderItem reminderItem)
		{
			ItemUpdated?.Invoke(this, new StorageChangedEventArgs(reminderItem));
		}
	}
}
