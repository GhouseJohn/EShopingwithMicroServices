using System.ComponentModel.DataAnnotations;

namespace Eshoping.Registration.model.UserRegistartion
{
    public class PermentaAddress
    {
        [Key]
        public int per_AddressId { get; set; }
        public string? HNo { get; set; }
        public string? streetName { get; set; }
        public string? Area { get; set; }
        public int District_Id { get; set; }
        public int City { get; set; }

    }

    public class TemporaryAddress
    {
        [Key]
        public int temporary_AddressId { get; set; }
        public string? HNo { get; set; }
        public string? streetName { get; set; }
        public string? Area { get; set; }
        public int District_Id { get; set; }
        public int City { get; set; }

    }
}
