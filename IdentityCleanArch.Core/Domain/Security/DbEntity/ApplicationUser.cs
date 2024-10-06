using Microsoft.AspNetCore.Identity;

namespace IdentityCleanArch.Core.Domain.Security.DbEntity;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
}
