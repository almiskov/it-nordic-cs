using System;

namespace methods_constructors
{
	class Program
	{
		static void Main(string[] args)
		{
			Pet pet1 = new Pet()
			{
				Kind = PetKind.Cat,
				Name = "Marselin",
				Sex = 'F',
				DateOfBirth = DateTimeOffset.Parse("2017-10-01")
			};

			Pet pet2 = new Pet()
			{
				Kind = PetKind.Dog,
				Name = "Jake",
				Sex = 'M',
				DateOfBirth = DateTimeOffset.Parse("2002-11-10")
			};

			Pet pet3 = new Pet()
			{
				Kind = PetKind.Elephant,
				Name = "Moooo",
				Sex = 'M',
				DateOfBirth = DateTimeOffset.Parse("1991-07-10")
			};

			pet1.WriteDescription(false);
			pet2.WriteDescription(true);
			pet3.WriteDescription();


		}
	}
}
