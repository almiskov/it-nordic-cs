using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorrespondenceEF.Domain
{
	[Table(nameof(Contractor), Schema = "dbo")]
	public class Contractor
	{
		public int Id { get; set; }

		[Required]
		[Column(TypeName ="VARCHAR(250)")]
		public string Name { get; set; }

		[Required]
		public Position Position { get; set; }
	}
}
