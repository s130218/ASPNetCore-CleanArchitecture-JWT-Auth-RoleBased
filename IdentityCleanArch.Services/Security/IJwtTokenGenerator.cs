using IdentityCleanArch.Core.Domain.Security.DbEntity;

namespace IdentityCleanArch.Services.Security;

public interface IJwtTokenGenerator
{
    Task<Tuple<string, int>> GenerateToken(ApplicationUser applicationUser);
}
