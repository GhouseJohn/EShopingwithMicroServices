using System.ComponentModel.DataAnnotations;

namespace Eshoping.Registration.model.UserRegistartion
{
    public class UserInfo
    {
        [Key]
        public int UserId { get; set; }
        public required string firstName { get; set; }
        public  string? middleName { get; set; }
        public required string lastName { get; set; }
        public int gender { get; set; }
        public bool IsMarried { get; set; } = false;
        public string? spouseName { get; set; }

    }
}
