using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorrespondenceEF.Domain
{
	[Table(nameof(PostalItem), Schema = "dbo")]
	public class PostalItem
	{
		public int Id { get; set; }

		[Required]
		[Column(TypeName = "VARCHAR(250)")]
		public string Name { get; set; }

		[Required]
		public int NumberOfPages { get; set; }
	}
}
