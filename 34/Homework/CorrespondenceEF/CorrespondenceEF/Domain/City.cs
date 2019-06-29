using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorrespondenceEF.Domain
{
	[Table(nameof(City), Schema = "dbo")]
	public class City
	{
		public int Id { get; set; }

		[Required]
		[Column(TypeName = "VARCHAR(250)")]
		public string Name { get; set; }
	}
}
