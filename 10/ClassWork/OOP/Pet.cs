using System;

namespace OOP
{
	class Pet
	{
		private char _sex;
		private byte _age;

		public Kind Kind { get; set; }
		public string Name { get; set; }

		public char Sex
		{
			get { return _sex; }
			set
			{
				if(value == 'M' || value == 'F')
					_sex = value;
				else
					throw new Exception("Only \'M\' or \'F\' letters");
			}
		}

		public byte Age
		{
			get { return _age; }
			set
			{
				if(value > 0 && value < 50)
					_age = value;
				else
					throw new Exception("Age can be more than 0 and less than 50 years.");
			}
		}

		private string PropertiesString
		{
			get { return $"{Name} is a {Kind} ({Sex}) of {Age} years old."; }
		}

		public void WritePropertiesToConsole()
		{
			Console.WriteLine(PropertiesString);
		}
	}
}
