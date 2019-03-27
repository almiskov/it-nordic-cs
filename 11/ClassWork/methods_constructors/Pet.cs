using System;

namespace methods_constructors
{
	class Pet
	{
		public PetKind Kind { get; set; }
		public string Name { get; set; }
		public char Sex { get; set; }
		public DateTimeOffset DateOfBirth { get; set; }

		public byte Age
		{
			get
			{
				TimeSpan age = DateTimeOffset.UtcNow.Subtract(DateOfBirth);
				return Convert.ToByte(Math.Floor(age.TotalDays / 365.242));
			}
		}

		public string FullDescription
		{
			get { return $"{Name} is a {Kind.ToString().ToLower()} ({Sex}) of {Age} years old."; }
		}

		public string ShortDescription
		{
			get { return $"{Name} is a {Kind.ToString().ToLower()}."; }
		}

		public void WriteDescription(bool showFullDescription = false)
		{
			Console.WriteLine(showFullDescription
				? FullDescription
				: ShortDescription);
		}
	}
}
