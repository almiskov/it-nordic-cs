using System;

namespace OOP
{
	class Program
	{
		static void Main(string[] args)
		{
			Pet cat = new Pet();

			cat.Kind = Kind.Cat;
			cat.Name = "Marselin";
			cat.Sex = 'F';
			cat.Age = 1;

			cat.WritePropertiesToConsole();

			Console.WriteLine();

			Pet dog = new Pet()
			{
				Kind = Kind.Dog,
				Name = "Jake",
				Sex = 'M',
				Age = 32
			};

			dog.WritePropertiesToConsole();

			Console.ReadKey();
		}
	}
}
