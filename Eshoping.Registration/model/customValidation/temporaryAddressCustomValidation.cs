using System.ComponentModel.DataAnnotations;

namespace Eshoping.Registration.model.customValidation
{
    public class temporaryAddressCustomValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var _temporaryAddress = validationContext.ObjectInstance as UserRegistration;
            if(_temporaryAddress == null)
            {
                return new ValidationResult($"White spece or null or empty value not accepected",new[] { nameof(_temporaryAddress) });
            }
            if(_temporaryAddress is not null)
            {
                foreach(var _tempvalue in _temporaryAddress.TemporaryAddress_model)
                {
                    if (string.IsNullOrEmpty(_tempvalue?.HNo) || string.IsNullOrWhiteSpace(_tempvalue.HNo))
                    {
                        return new ValidationResult($"White spece or null or empty value not accepected");
                    }
                    if (string.IsNullOrEmpty(_tempvalue?.streetName) || string.IsNullOrWhiteSpace(_tempvalue.streetName))
                    {
                        return new ValidationResult($"White spece or null or empty value not accepected");
                    }
                    //else if(_tempvalue.streetName.Length > 5)
                    //{
                    //    return new ValidationResult($"minimum 5 char Req");

                    //}
                    if (string.IsNullOrEmpty(_tempvalue?.Area) || string.IsNullOrWhiteSpace(_tempvalue.Area))
                    {
                        return new ValidationResult($"White spece or null or empty value not accepected");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
