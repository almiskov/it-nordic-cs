﻿using System;

namespace Reminder
{
	class ReminderItem
	{
		public DateTimeOffset AlarmDate { get; set; }
		public string AlarmMessage { get; set; }

		public TimeSpan TimeToAlarm
		{
			get { return AlarmDate.Subtract(DateTimeOffset.UtcNow); }
		}

		public bool IsOutdated
		{
			get { return TimeToAlarm < TimeSpan.Zero; }
		}

		public ReminderItem(DateTimeOffset alarmDate, string alarmMessage)
		{
			AlarmDate = alarmDate;
			AlarmMessage = alarmMessage;
		}

		public virtual void WriteProperties()
		{
			Console.WriteLine(
				$"{this.GetType().Name}\n" +
				$"{nameof(AlarmDate)}: {AlarmDate}\n" +
				$"{nameof(AlarmMessage)}: {AlarmMessage}\n" +
				$"{nameof(TimeToAlarm)}: {TimeToAlarm}\n" +
				$"{nameof(IsOutdated)}: {IsOutdated}");
		}
	}
}
