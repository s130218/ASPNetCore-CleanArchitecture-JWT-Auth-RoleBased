using IdentityCleanArch.Core.Domain.Security.DbEntity;
using IdentityCleanArch.Core.ServiceResult;
using IdentityCleanArch.Features.Security.Auth.Dto;
using IdentityCleanArch.Services.Security.AuthenticationService;
using Microsoft.AspNetCore.Identity;

namespace IdentityCleanArch.Features.Security.Auth.Factories
{
    public class AuthFactory : IAuthFactory
    {
        #region ctor
        private readonly IAuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthFactory(IAuthService authService, UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }
        #endregion

        #region Method
        public async Task<ServiceResult> MapAndRegisterNewUserAsync(RegistrationRequestDto dto)
        {
            var mappedData = MapToEntity(dto, new RegistrationRequest());
            var serviceResp = await _authService.RegisterNewUserAsync(mappedData).ConfigureAwait(false);
            return serviceResp;
        }
        #endregion

        #region Mapping
        private RegistrationRequest MapToEntity(RegistrationRequestDto dto, RegistrationRequest entity)
        {
            entity.Email = dto.Email;
            entity.Name = dto.Name;
            entity.PhoneNumber = dto.Name;
            entity.Password = dto.Password;
            return entity;
        }

        public async Task<List<ApplicationUserDto>> MapAndGetUsers(List<ApplicationUser> users)
        {
            if (users == null || users.Count == 0)
            {
                return new List<ApplicationUserDto>();
            }

            var results = new List<ApplicationUserDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                results.Add(new ApplicationUserDto
                {
                    UserId = user.Id,
                    Name = user.Name,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Roles = roles
                });
            }
            return results;
        }
        #endregion
    }
}
