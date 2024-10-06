using IdentityCleanArch.Core.Domain.Security.DbEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityCleanArch.Services.Security;

public class JWTTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtOptions _jwtOptions;
    private readonly UserManager<ApplicationUser> _userManager;

    public JWTTokenGenerator(IOptions<JwtOptions> jwtOptions, UserManager<ApplicationUser> userManager)
    {
        _jwtOptions = jwtOptions.Value;
        _userManager = userManager;
    }

    public async Task<Tuple<string, int>> GenerateToken(ApplicationUser applicationUser)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Email, applicationUser.Email),
            new(JwtRegisteredClaimNames.Sub, applicationUser.Id),
            new(JwtRegisteredClaimNames.Name, applicationUser.UserName)
        };

        var roles = await _userManager.GetRolesAsync(applicationUser);
        claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));


        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = _jwtOptions.Audience,
            Issuer = _jwtOptions.Issuer,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddMinutes(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwt = tokenHandler.WriteToken(token);
        var expiryMinute = tokenDescriptor.Expires.Value - DateTime.Now;

        return Tuple.Create(jwt, expiryMinute.Minutes);
    }
}
