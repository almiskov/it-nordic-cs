using System;

namespace Generics
{
	class Program
	{
		static void Main(string[] args)
		{
			Account<int> acInt = new Account<int>(1, "Alexander");
			Account<string> acString = new Account<string>("AAA", "Anna");
			Account<Guid> acGuid = new Account<Guid>(Guid.NewGuid(), "Marselin");

			acInt.WriteProperties();
			acString.WriteProperties();
			acGuid.WriteProperties();
		}
	}
}
