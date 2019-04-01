using System;

namespace Inheritance
{
	class Program
	{
		static void Main(string[] args)
		{
			BaseDocument[] bdArray = new BaseDocument[5];

			bdArray[0] = new BaseDocument("Some Document", "wp000100", DateTimeOffset.Parse("1890-03-25"));
			bdArray[1] = new Passport("1410090000", DateTimeOffset.Parse("2010-07-30"), "Russia", "Alexander");
			bdArray[2] = new Passport("15451315", DateTimeOffset.MinValue);
			bdArray[3] = new BaseDocument("Another document", "xxffsdf", DateTimeOffset.MaxValue);
			bdArray[4] = new Passport("1412948948", DateTimeOffset.Parse("1991-12-24"));

			foreach (var baseDocument in bdArray)
			{
				baseDocument.WriteToConsole();
			}

			foreach (var baseDocument in bdArray)
			{
				if(baseDocument is Passport)
				{
					baseDocument.IssueDate = DateTimeOffset.Now;
				}
			}

			Console.WriteLine();

			foreach (var baseDocument in bdArray)
			{
				baseDocument.WriteToConsole();
			}
		}
	}
}
