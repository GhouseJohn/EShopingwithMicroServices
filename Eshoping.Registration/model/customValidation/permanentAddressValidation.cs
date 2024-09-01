using System.ComponentModel.DataAnnotations;

namespace Eshoping.Registration.model.customValidation
{
    public class permanentAddressValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var _permentAddress = validationContext.ObjectInstance as UserRegistration;
            if (_permentAddress is not null)
            {
                if (string.IsNullOrEmpty(_permentAddress.permanentAddressForComminication?.HNo) || string.IsNullOrWhiteSpace(_permentAddress.permanentAddressForComminication.HNo))
                {
                    return new ValidationResult($"White spece or null or empty value not accepected");
                }
                else if (string.IsNullOrEmpty(_permentAddress.permanentAddressForComminication.streetName) || string.IsNullOrWhiteSpace(_permentAddress.permanentAddressForComminication.streetName))
                {
                    return new ValidationResult($"White spece or null or empty value not accepected");
                }
                else if (string.IsNullOrEmpty(_permentAddress.permanentAddressForComminication.Area) || string.IsNullOrWhiteSpace(_permentAddress.permanentAddressForComminication.Area))
                {
                    return new ValidationResult($"White spece or null or empty value not accepected");
                }
                else if (string.IsNullOrEmpty(_permentAddress.permanentAddressForComminication.Dist) || string.IsNullOrWhiteSpace(_permentAddress.permanentAddressForComminication.Dist))
                {
                    return new ValidationResult($"White spece or null or empty value not accepected");
                }
            }
            return ValidationResult.Success;
        }
    }
}
