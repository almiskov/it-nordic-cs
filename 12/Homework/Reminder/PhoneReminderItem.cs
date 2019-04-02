using System;

namespace Reminder
{
	class PhoneReminderItem : ReminderItem
	{
		public string PhoneNumber { get; set; }

		public PhoneReminderItem(DateTimeOffset alarmDate, string alarmMessage, string phoneNumber)
			: base(alarmDate, alarmMessage)
		{
			PhoneNumber = phoneNumber;
		}

		public PhoneReminderItem(ReminderItem reminder, string phoneNumber)
			: base(reminder.AlarmDate, reminder.AlarmMessage)
		{
			PhoneNumber = phoneNumber;
		}

		public override void WriteProperties()
		{
			base.WriteProperties();
			Console.WriteLine(
				$"{nameof(PhoneNumber)}: {PhoneNumber}");
		}
	}
}
