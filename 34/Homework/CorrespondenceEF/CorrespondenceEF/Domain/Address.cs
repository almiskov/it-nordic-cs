using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorrespondenceEF.Domain
{
	[Table(nameof(Address), Schema = "dbo")]
	public class Address
	{
		public int Id { get; set; }

		[Required]
		public City City { get; set; }

		[Required]
		[Column(TypeName = "VARCHAR(250)")]
		public string FullAddress { get; set; }
	}
}
