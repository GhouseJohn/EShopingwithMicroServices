using System;
using System.ComponentModel.DataAnnotations;

namespace Eshoping.Registration.model.customValidation
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {

        //In Bytes:5×1024×1024=5,242,880 byt
        //In Kilobytes(KB) : 5,242,880/1024 =5120KB
        //In Megabytes(MB) :5,242,880/1024 * 1024 =5MB
        //So file size is 5MB

        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Maximum allowed file size is {_maxFileSize} bytes.";
        }
    }
}
