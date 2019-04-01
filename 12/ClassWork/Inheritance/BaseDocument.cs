using System;

namespace Inheritance
{
	class BaseDocument
	{
		public string DocName { get; set; }
		public string DocNumber { get; set; }
		public DateTimeOffset IssueDate { get; set; }

		public BaseDocument(string docName, string docNumber, DateTimeOffset issueDate)
		{
			DocName = docName;
			DocNumber = docNumber;
			IssueDate = issueDate;
		}

		public virtual string PropertiesString
		{
			get { return
					$"{nameof(DocName)}: {DocName}, " +
					$"{nameof(DocNumber)}: {DocNumber}, " +
					$"{nameof(IssueDate)}: {IssueDate:dd-MM-yyyy}"; }
		}

		public void WriteToConsole()
		{
			Console.WriteLine(PropertiesString);
		}
	}
}
