using IdentityCleanArch.Core.Domain.Security.DbEntity;
using IdentityCleanArch.Features.Security.Auth.Dto;
using IdentityCleanArch.Features.Security.Auth.Factories;
using IdentityCleanArch.Services.Security.AuthenticationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCleanArch.Features.Security.Auth.Controller;

[Route("v1/auth")]
[ApiController]
public class AuthAPIController : ControllerBase
{
    private readonly IAuthFactory _authFactory;
    private readonly IAuthService _authService;

    public AuthAPIController(IAuthFactory authFactory, IAuthService authService)
    {
        _authFactory = authFactory;
        _authService = authService;
    }


    #region Method
    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var resp = await _authService.LoginAsync(model).ConfigureAwait(false);
        return Ok(resp);
    }

    [Route("register")]
    [HttpPost]
    [Authorize(Policy = AuthorizePolicy.SuperAdminRole)]
    public async Task<IActionResult> RegisterAsync([FromBody] RegistrationRequestDto model)
    {
        var resp = await _authFactory.MapAndRegisterNewUserAsync(model).ConfigureAwait(false);
        return Ok(resp);
    }

    [Route("users")]
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        var result = await _authService.GetAllUsersAsync().ConfigureAwait(false);
        if (result.Status)
        {
            var dto = await _authFactory.MapAndGetUsers(result.Data).ConfigureAwait(false);
            return Ok(dto);
        }
        return Ok(result);
    }

    [Route("role/assign")]
    [HttpPut]
    [Authorize(Policy = AuthorizePolicy.SuperAdminRole)]
    public async Task<IActionResult> UpdateRoleAsync([FromBody] AssignNewRoleDTO model)
    {
        var resp = await _authService.AssignNewRoleAsync(model.UserId, model.Role.ToUpper());
        return Ok(resp);
    }

    [Route("users/{userId}")]
    [HttpDelete]
    [Authorize(Policy = AuthorizePolicy.SuperAdminRole)]
    public async Task<IActionResult> DeleteUserAsync(string userId)
    {
        var users = await _authService.DeleteUserAsync(userId).ConfigureAwait(false);
        return Ok(users);
    }

    #endregion
}
