namespace IdentityCleanArch.Core.Domain.Security.DbEntity;

public static class FixedRoles
{
    public const string CommonUser = "CommonUser";
    public const string Admin = "Admin";
    public const string SuperAdmin = "SuperAdmin";

    public static List<string> GetAllRoles()
    {
        var roles = new List<string>
        {
            CommonUser,
            Admin,
            SuperAdmin
        };
        return roles;
    }
}

public static class AuthorizePolicy
{
    public const string AdminRole = "RequireAdminRole";
    public const string CommonUserRole = "RequireCommonUserRole";
    public const string SuperAdminRole = "RequireSuperAdminRole";
}
