using IdentityCleanArch.Features.Security.Auth.Factories;

namespace IdentityCleanArch.FactoryDependencyExtension;

public static class SecurityIdentityFactories
{
    public static void RegisterSecurityIdentityFactories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAuthFactory), typeof(AuthFactory));
    }

}
