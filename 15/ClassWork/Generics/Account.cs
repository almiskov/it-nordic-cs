using System;

namespace Generics
{
	class Account<T>
	{
		public T TId { get; private set; }
		public string Name { get; private set; }

		public Account(T Tid, string name)
		{
			TId = Tid;
			Name = name;
		}

		public void WriteProperties()
		{
			Console.WriteLine(
				$"ID: {TId}\n" +
				$"Name: {Name}");
		}
	}
}
