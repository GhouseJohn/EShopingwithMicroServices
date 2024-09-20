using Eshoping.Registration.model.customValidation;
using System.ComponentModel.DataAnnotations;

namespace Eshoping.Registration.model
{
    public sealed class UserRegistration
    {
        [Required]
        public required string firstName { get; set; }
        public string? middleName { get; set; }
        [Required]
        public required string lastName { get; set; }
        [Required]
        public int gender { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public required string email { get; set; }
        [Required]
        [Phone(ErrorMessage = "Phone Number Req")]
        public required string phonenumber { get; set; }

        [Required]
        public bool Ismarried { get; set; } = false;
        [spouseCustomValidation]
        public string? spouseName { get; set; }

        //[Required]
        //[DataType(DataType.Upload)]
        //[MaxFileSize(5 * 1024 * 1024)]
        //[AllowedExtensions(new string[] { ".jpg", ".png", ".gif" })]
        //public required IFormFile MyProperty { get; set; }


        //[permanentAddressValidation]
        //public permanent_Address_ForComminication_model? permanentAddressForComminication { get; set; }
        [temporaryAddressCustomValidation]
        public required List<TemporaryAddress_model> TemporaryAddress_model { get; set; }
    }

    public class TemporaryAddress_model
    {
        [Required]
        [Display(Name = "House Number")]
        public required string HNo { get; set; }
        [Required]
        public required string streetName { get; set; }
        [Required]
        public required string Area { get; set; }
        [Required]
        public required int District_Id { get; set; }
        [Required]
        public int Cityvalue_id { get; set; }
    }

}


