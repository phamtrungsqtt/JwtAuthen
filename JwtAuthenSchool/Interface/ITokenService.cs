using JwtAuthenSchool.Models.Authentication;

namespace JwtAuthenSchool.Interface
{
    public interface ITokenService
    {
        public string GenerateJWT(UserModel userInfo);
        public UserModel Authenticate(LoginModel loginInfo);
    }
}
