using System;

namespace People
{
	class AppIO
	{
		private readonly ConsoleWriter _writer;

		public AppIO(ConsoleWriter writer)
		{
			_writer = writer;
		}

		#region Getting information from user

		public string AskCorrectName() // на самом деле далеко не всегда корректное)
		{
			string name;

			while (true)
			{
				_writer.WriteYellow("Name: ");

				name = Console.ReadLine().Trim();

				if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
				{
					_writer.WriteLineRed("Name is too short or has't been input. Please try again.");
				}
				else
				{
					return name;
				}
			}
		} 

		public byte AskCorrectAge()
		{
			byte age;

			while (true)
			{
				_writer.WriteYellow("Age: ");

				if (byte.TryParse(Console.ReadLine(), out age) && age > 0 && age <= 150)
				{
					return age;
				}
				else
				{
					_writer.WriteLineRed("Age must be an integer from 1 to 150. Please try again.");
				}
			}
		}

		#endregion

		#region Outputting information to user

		public void WriteIntroducing(int numberOfPeople)
		{
			_writer.WriteLineBlue($"Please input names and ages of {numberOfPeople} people.\n" +
				$"Name must contain at least 2 symbols.\n" +
				$"Age must be an integer from 1 to 150.");
		}

		public void WritePersonInfoAccepted(int personNumber)
		{
			_writer.WriteLineGreen($"Information on the {personNumber} person accepted.");
		}

		public void WriteSummaryHeader(int yearsForward)
		{
			_writer.WriteLineYellow($"\nSummary in {yearsForward} years:");
		}

		public void WritePersonInfo(string personInfo)
		{
			_writer.WriteLineYellow(personInfo);
		}

		#endregion
	}
}
