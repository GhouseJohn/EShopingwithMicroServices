using System.ComponentModel.DataAnnotations;

namespace Eshoping.Registration.model.JWTAccess
{
    public class AspNetUSer
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string Name { get; set; }
        public string?  Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PasswordHash { get; set; }
        public int AccessFailedCount { get; set; }
        public bool EmailConfirmed { get; set; } = false;
        public bool PhoneNumberConfirmed { get; set; }=false;
        public bool TwoFactorEnabled { get; set; } = false;
        public bool LockoutEnabled { get; set; } = false;
    }
}
