using IdentityCleanArch.Core.Domain.Security.DbEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityCleanArch.Services.Security;

public class DbInitializer
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        List<string> roleNames = FixedRoles.GetAllRoles();
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Optionally, create a default SuperAdmin user
        var superAdmin = new ApplicationUser
        {
            Name = "sadmin",
            UserName = "sadmin",
            Email = "superadmin@example.com"
        };

        string superAdminPassword = "SuperAdmin123!";
        var user = await userManager.FindByEmailAsync(superAdmin.Email);

        if (user == null)
        {
            var createSuperAdmin = await userManager.CreateAsync(superAdmin, superAdminPassword);
            if (createSuperAdmin.Succeeded)
            {
                await userManager.AddToRoleAsync(superAdmin, FixedRoles.SuperAdmin);
            }
        }
    }
}
