using IdentityCleanArch.FactoryDependencyExtension;

namespace IdentityCleanArch.Services.FactoryDependencyExtension;

public static class ConfigureExtension
{
    public static void ConfigureClientServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterSecurityIdentityFactories();
    }
}
