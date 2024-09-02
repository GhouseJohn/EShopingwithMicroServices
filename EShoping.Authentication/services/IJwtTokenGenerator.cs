using EShoping.Authentication.model;

namespace EShoping.Authentication.services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);

    }
}
