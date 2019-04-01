using System;

namespace Inheritance
{
	class Passport : BaseDocument
	{
		public string PersonName { get; set; }
		public string Country { get; set; }

		public Passport(string docNumber, DateTimeOffset issueDate, string personName, string country)
			: base("Passport", docNumber, issueDate)
		{
			PersonName = personName;
			Country = country;
		}

		public Passport(string docNumber, DateTimeOffset issueDate)
			: base("Passport", docNumber, issueDate) { }

		public Passport(string docNumber, DateTimeOffset issueDate, string personName)
			: this(docNumber, issueDate)
		{
			PersonName = personName;
		}

		public Passport(BaseDocument baseDocument, string personName, string country)
			: base("Passport", baseDocument.DocNumber, baseDocument.IssueDate)
		{
			PersonName = personName;
			Country = country;
		}

		public override string PropertiesString
		{
			get
			{
				return
				  $"{nameof(DocName)}: {DocName}, " +
				  $"{nameof(DocNumber)}: {DocNumber}, " +
				  $"{nameof(IssueDate)}: {IssueDate:dd-MM-yyyy}, " +
				  $"{nameof(PersonName)}: {PersonName}, " +
				  $"{nameof(Country)}: {Country}";
			}
		}

		public void ChangeIssueDate(DateTimeOffset newDIssueDate)
		{
			this.IssueDate = newDIssueDate;
		}
	}
}
