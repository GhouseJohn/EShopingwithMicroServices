using System.ComponentModel.DataAnnotations;

namespace Eshoping.Registration.model.UserRegistartion
{
    public class Gender
    {
        [Key]
        public int Gender_Id { get; set; }
        public string Gender_type { get; set; }
    }
}
