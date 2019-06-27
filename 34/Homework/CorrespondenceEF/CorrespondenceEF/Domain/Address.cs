namespace CorrespondenceEF.Domain
{
	public class Address
	{
		public int Id { get; set; }
		public City City { get; set; }
		public string FullAddress{ get; set; }
	}
}
