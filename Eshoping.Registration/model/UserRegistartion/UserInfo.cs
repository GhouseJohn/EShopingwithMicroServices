using System.ComponentModel.DataAnnotations;

namespace Eshoping.Registration.model.UserRegistartion
{
    public class UserInfo
    {
        [Key]
        public int UserId { get; set; }
        public required string firstName { get; set; }
        public  string? midName { get; set; }
        public required string lastName { get; set; }
        public int gender { get; set; }
        public bool IsMarried { get; set; } = false;
        public int permentAddress { get; set; }
        public int TemporaryAddress { get; set; }

    }
}
