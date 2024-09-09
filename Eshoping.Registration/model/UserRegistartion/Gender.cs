using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eshoping.Registration.model.UserRegistartion
{
    public class Gender
    {
        [Key]
        public int Gender_Id { get; set; }
        [DisplayName("Gender")]
        public string? Gender_type { get; set; }
    }
}
