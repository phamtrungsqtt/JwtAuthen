using JwtAuthenSchool.Interface;
using JwtAuthenSchool.Models.Authentication;
using JwtAuthenSchool.Models.Configs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthenSchool.Services
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<JwtAuthConfig> _jwtConfigs;

        public TokenService(IOptions<JwtAuthConfig> jwtConfig)
        {
            _jwtConfigs = jwtConfig;
        }

        public UserModel Authenticate(LoginModel loginInfo)
        {
            UserModel user = null;

            if (loginInfo.Username.Equals("trungpv8", StringComparison.OrdinalIgnoreCase) && loginInfo.Password == "trungpv8")
            {
                user = new UserModel { Username = "trungpv8", Email = "trungpv8@fpt.com.vn", Password = "trungpv8", Role = "Admin", Result = 1 };
            }
            else
            {
                user = new UserModel { Result = 0 };
            }
            return user;
        }

        public string GenerateJWT(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfigs.Value.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Handle Claims with JWT
            var claims = new List<Claim>() {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim("Roles", userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            //End

            //Add role if exist Role in user
            if (!string.IsNullOrEmpty(userInfo.Role))
            {
                var RoleClam = new Claim(ClaimTypes.Role, userInfo.Role);
                claims.Add(RoleClam);
            }

            var token = new JwtSecurityToken(_jwtConfigs.Value.Issuer,
              _jwtConfigs.Value.Audience,
              claims,
              expires: DateTime.Now.AddMinutes(_jwtConfigs.Value.Expires),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
