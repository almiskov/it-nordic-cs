namespace People
{
	class App
	{
		private readonly AppIO _io;

		public App(ConsoleWriter writer)
		{
			_io = new AppIO(writer);
		}

		public void Run()
		{
			int numberOfPeople = 3;

			Person[] persons = new Person[numberOfPeople];
			string name;
			byte age;

			byte yearsForward = 4;
			string fullInfoInYears;


			_io.WriteIntroducing(numberOfPeople);

			for (int i = 0; i < persons.Length; i++)
			{
				name = _io.AskCorrectName();
				age = _io.AskCorrectAge();

				persons[i] = new Person(name, age);

				_io.WritePersonInfoAccepted(i + 1);
			}

			_io.WriteSummaryHeader(yearsForward);

			for (int i = 0; i < persons.Length; i++)
			{
				fullInfoInYears = persons[i].GetFullInfoInYears(yearsForward);
				_io.WritePersonInfo(fullInfoInYears);
			}
		}
	}
}
