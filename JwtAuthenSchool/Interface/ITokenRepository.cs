using JwtAuthenSchool.Models.Authentication;

namespace JwtAuthenSchool.Interface
{
    public interface ITokenRepository
    {
        UserModel GetUserName(LoginModel login);
    }
}
