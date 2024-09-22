using Microsoft.AspNetCore.Identity;

namespace HealthApp_Backend.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
        
    }
}
