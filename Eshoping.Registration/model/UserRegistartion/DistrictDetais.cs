using System.ComponentModel.DataAnnotations;

namespace Eshoping.Registration.model.UserRegistartion
{
    public class DistrictDetais
    {
        [Key]
        public int DistrictId { get; set; }
        public string? District_Name { get; set; }

    }

    public class CityDetails
    {
        [Key]
        public int CityId { get; set; }
        public string? City_Name { get; set; }
        public int DistId { get; set; }

    }
}
