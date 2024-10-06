using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityCleanArch.DependencyResolution;

public class DependencyRegistrar
{
    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureCommonServiceModule(configuration);
    }
}
