using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson_34_Classwork.Domain
{
    [Table("Customer", Schema = "dbo")]
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [Column("Name", TypeName = "VARCHAR(50)")]
        public string Name { get; set; }
    }
}
