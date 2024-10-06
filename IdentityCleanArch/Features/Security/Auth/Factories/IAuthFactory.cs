using IdentityCleanArch.Core.Domain.Security.DbEntity;
using IdentityCleanArch.Core.ServiceResult;
using IdentityCleanArch.Features.Security.Auth.Dto;

namespace IdentityCleanArch.Features.Security.Auth.Factories;

public interface IAuthFactory
{
    Task<ServiceResult> MapAndRegisterNewUserAsync(RegistrationRequestDto dto);
    Task<List<ApplicationUserDto>> MapAndGetUsers(List<ApplicationUser> entities);
}
