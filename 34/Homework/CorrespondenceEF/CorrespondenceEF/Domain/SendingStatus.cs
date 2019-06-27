using System;

namespace CorrespondenceEF.Domain
{
	public class SendingStatus
	{
		public int Id { get; set; }
		public PostalItem PostalItem { get; set; }
		public DateTimeOffset UpdateStatusDateTime { get; set; }
		public Status Status { get; set; }
		public Contractor SendingContractor { get; set; }
		public Address SendingAddress { get; set; }
		public Contractor RecievingContractor { get; set; }
		public Address RecievingAddress { get; set; }
	}
}
