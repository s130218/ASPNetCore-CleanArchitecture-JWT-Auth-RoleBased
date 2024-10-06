using IdentityCleanArch.Core.Infrastructure.DataAccess;
using IdentityCleanArch.EntityFrameWork.Repository;
using IdentityCleanArch.Services.Security;
using IdentityCleanArch.Services.Security.AuthenticationService;
using IdentityCleanArch.Services.Security.AuthService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityCleanArch.DependencyResolution;

public static class CommonModule
{
    public static void ConfigureCommonServiceModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        services.AddTransient(typeof(IJwtTokenGenerator), typeof(JWTTokenGenerator));
        services.AddScoped(typeof(IAuthService), typeof(AuthService));
    }
}
