using JwtAuthenSchool.Interface;
using JwtAuthenSchool.Models.Authentication;

namespace JwtAuthenSchool.Services.Repository
{
    public class TokenRepository : ITokenRepository
    {
        public UserModel GetUserName(LoginModel login)
        {
            dynamic result = null;
            //var conn = GetConnection(Connect.Write);

            try
            {

                //if (conn.State == ConnectionState.Closed)
                //{
                //    conn.Open();
                //}
                //if (conn.State == ConnectionState.Open)
                //{


                //    string query = "SELECT id,username,password,fullname,role,status,token,description,email FROM " + Contanst.SCHEMA + "Role WHERE status=1 and username = :username";

                //    result = SqlMapper.Query<UserEntity>(conn, query, new { username = login.Username.Trim() }).FirstOrDefault();
                //    conn.Close();
                //}
            }
            catch (Exception ex)
            {
                //_logger.LogInformation("[TokenRepository][GetUserName] " + ex.Message);
                //string errorMessage = "[TokenRepository][GetUserName] " + ex.Message;
                //MailService ms = new MailService();
                //MailModel mm = new MailModel();
                //mm.To = ConfigurationManager.AppSetting["AppSetting:To"];
                //mm.Parameters = "Message= " + errorMessage + ",demo = linh ";
                //ms.TestingMail(mm);
            }
            finally
            {
                //conn.Close();
            }
            return result;
        }
    }
}
