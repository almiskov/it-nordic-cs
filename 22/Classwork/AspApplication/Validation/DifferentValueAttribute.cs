using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace AspApplication.Validation
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	[SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes", Justification = "This attribute is designed to be a base class for other attributes.")]

	public class DifferentValueAttribute : ValidationAttribute
	{
		public string OtherProperty { get; set; }
		public object DataAnnotationsResources { get; private set; }

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
			if (otherPropertyInfo == null)
			{
				return new ValidationResult($"Can't find the property {OtherProperty}");
			}

			object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
			if (Equals(value, otherPropertyValue))
			{
				return new ValidationResult($"The value of {validationContext.MemberName} should not be the same as {OtherProperty}");
			}
			return ValidationResult.Success;
		}
	}
}
