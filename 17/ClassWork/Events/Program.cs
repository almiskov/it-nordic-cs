using System;

namespace Events
{
	class Program
	{
		static void Main(string[] args)
		{
			var worker = new Worker();

			worker.WorkPerformed += Worker_WorkPerformed;
			worker.WorkCompleted += Worker_WorkCompleted;

			worker.DoWork(6, WorkType.Work);

		}

		private static void Worker_WorkCompleted(object sender, EventArgs e)
		{
			Console.WriteLine("Work completed: " + sender.GetHashCode());
		}

		private static void Worker_WorkPerformed(int hours, WorkType workType)
		{
			Console.WriteLine($"Worktype: {workType}, hours {hours}");
		}
	}
}
