using System.ComponentModel.DataAnnotations;

namespace Eshoping.Registration.model.UserRegistartion
{
    public class Test
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
    }
}
