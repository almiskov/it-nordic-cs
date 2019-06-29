using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorrespondenceEF.Domain
{
	[Table(nameof(Status), Schema = "dbo")]
	public class Status
	{
		public int Id { get; set; }

		[Required]
		[Column(TypeName = "VARCHAR(20)")]
		public string Name { get; set; }
	}
}
