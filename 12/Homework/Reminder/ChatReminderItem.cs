using System;

namespace Reminder
{
	class ChatReminderItem : ReminderItem
	{
		public string ChatName { get; set; }
		public string AccountName { get; set; }

		public ChatReminderItem(DateTimeOffset alarmDate, string alarmMessage, string chatName, string accountName)
			: base(alarmDate, alarmMessage)
		{
			ChatName = chatName;
			AccountName = accountName;
		}

		public ChatReminderItem(ReminderItem reminder, string chatName, string accountName)
			: base(reminder.AlarmDate, reminder.AlarmMessage)
		{
			ChatName = chatName;
			AccountName = accountName;
		}

		public override void WriteProperties()
		{
			base.WriteProperties();
			Console.WriteLine(
				$"{nameof(ChatName)}: {ChatName}\n" +
				$"{nameof(AccountName)}: {AccountName}");
		}
	}
}
