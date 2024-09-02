using Microsoft.AspNetCore.Identity;

namespace EShoping.Authentication.model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

    }
}
