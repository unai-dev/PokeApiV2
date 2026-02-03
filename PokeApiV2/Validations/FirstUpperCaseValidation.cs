using System.ComponentModel.DataAnnotations;

namespace PokeApiV2.Validations
{
    public class FirstUpperCaseValidation: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
               
            if (value is null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var valueString = value.ToString()!;
            var firstCharValue = valueString[0].ToString();

            if (firstCharValue != firstCharValue.ToUpper())
            {
                return new ValidationResult("The first letter must be capital");
            }

            return ValidationResult.Success;

        }
    }
}
