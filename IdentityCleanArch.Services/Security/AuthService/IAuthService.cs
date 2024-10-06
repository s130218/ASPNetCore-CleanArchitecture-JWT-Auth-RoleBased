using IdentityCleanArch.Core.Domain.Security.DbEntity;
using IdentityCleanArch.Core.ServiceResult;

namespace IdentityCleanArch.Services.Security.AuthenticationService;

public interface IAuthService
{
    Task<ServiceResult> RegisterNewUserAsync(RegistrationRequest registrationRequest);
    Task<ServiceResult<LoginResponse>> LoginAsync(LoginModel loginModel);
    Task<ServiceResult<List<ApplicationUser>>> GetAllUsersAsync();
    Task<ServiceResult> AssignNewRoleAsync(string userId, string newRoleName);
    Task<ServiceResult> DeleteUserAsync(string userId);


}
