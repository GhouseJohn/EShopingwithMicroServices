using System.ComponentModel.DataAnnotations;

namespace Eshoping.Registration.model.customValidation
{
    public class spouseCustomValidation : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            UserRegistration? maritualStatus = validationContext.ObjectInstance as UserRegistration;
            if (maritualStatus.Ismarried)
            {
                if (string.IsNullOrEmpty(maritualStatus?.spouseName) || string.IsNullOrWhiteSpace(maritualStatus.spouseName))
                {
                    return new ValidationResult($"White spece or null or empty value not accepected");
                }
            }
            return ValidationResult.Success;
        }
    }
}
