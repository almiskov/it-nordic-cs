using AspApplication.Validation;
using System.ComponentModel.DataAnnotations;

namespace AspApplication.Models
{
	public class CityPatchModel
	{
		[MaxLength(100, ErrorMessage = "The name of the city should not be longer {1} characters")]
		public string Name { get; set; }

		//[DifferentValue(OtherProperty = "Name")]
		[MaxLength(70, ErrorMessage = "Description should not be longer {1} characters")]
		public string Description { get; set; }

		[Range(0, 100, ErrorMessage = "Number of points of interest should be between {1} and {2} characters")]
		public int NumberOfPointsOfInterest { get; set; }
	}
}
