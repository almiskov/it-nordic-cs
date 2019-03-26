using System;

namespace People
{
	class Person
	{
		private byte _age;
		private byte _timeSpan;

		public string Name { get; set; }

		public byte Age
		{
			get
			{
				return _age;
			}
			set
			{
				if (value > 0 && value <= 150)
					_age = value;
				else
					throw new ArgumentOutOfRangeException(nameof(_age), "Age must be an integer from 1 to 150.");
			}
		}

		private string FullInformationStringInYears
		{
			get
			{
				return $"Name: {Name}, age in {_timeSpan} years: {Age + _timeSpan}";
			}
		}

		public Person(string name, byte age)
		{
			Name = name;
			_age = age;
		}

		public string GetFullInfoInYears(byte yearsForward)
		{
			_timeSpan = yearsForward;
			return FullInformationStringInYears;
		}
	}
}
