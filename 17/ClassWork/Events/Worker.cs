﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
	public enum WorkType
	{
		Work,
		DoNothing
	}

	public delegate void WorkPerformedEventHandler(int hours, WorkType workType);

	public class Worker
	{
		public event WorkPerformedEventHandler WorkPerformed;
		public event EventHandler WorkCompleted;

		public void DoWork(int hours, WorkType workType)
		{
			for (int i = 0; i < hours; i++)
			{
				OnWorkPerformed(i + 1, workType);
			}

			OnWorkCompleted(this, EventArgs.Empty);
		}

		protected virtual void OnWorkPerformed(int data, WorkType workType)
		{
			WorkPerformed?.Invoke(data, workType);
		}

		protected virtual void OnWorkCompleted(object sender, EventArgs e)
		{
			WorkCompleted?.Invoke(sender, e);
		}
	}
}
