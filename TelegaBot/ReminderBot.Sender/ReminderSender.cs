using ReminderBot.Reminder;
using ReminderBot.Storage;
using System;
using System.Collections.Generic;

namespace ReminderBot.Sender
{
	public class ReminderSender
	{
		private ReminderStorage _reminderStorage;
		private List<ReminderItem> _remindersToSend;

		private ReminderItem _nextReminderItemToSend;

		public ReminderSender()
		{
			_reminderStorage = ReminderStorage.GetInstance();

			_reminderStorage.ItemAdded += (s, e) =>
			{
				_remindersToSend.Add(e.ReminderItem);
				_nextReminderItemToSend = FindNextReminderItem();
			};

			_remindersToSend = new List<ReminderItem>();
		}

		public void SendNext()
		{
			if (_nextReminderItemToSend != null && _nextReminderItemToSend.IsOutdated)
			{
				SendToConsole(_nextReminderItemToSend);

				_nextReminderItemToSend.IsSent = true;
				_remindersToSend.Remove(_nextReminderItemToSend);

				_nextReminderItemToSend = FindNextReminderItem();
			}
			else
			{
				Console.WriteLine($"({DateTimeOffset.Now.DateTime.ToLongTimeString()}) Nothing to send");
			}
		}

		private void SendToConsole(ReminderItem reminderItem)
		{
			Console.WriteLine($"({DateTimeOffset.Now.DateTime.ToLongTimeString()}) {reminderItem.GetShortInfo()}");
		}

		private ReminderItem FindNextReminderItem()
		{
			ReminderItem nextReminderItem = null;

			if (_remindersToSend.Count > 0)
			{
				nextReminderItem = _remindersToSend[0];

				foreach (ReminderItem ri in _remindersToSend)
				{
					if (ri.ReminderDate < nextReminderItem.ReminderDate)
						nextReminderItem = ri;
				}
			}

			return nextReminderItem;
		}
	}
}

