namespace JwtAuthenSchool.Utility
{
    public class Contanst
    {
        public static string SCHEMA = ConfigurationManager.AppSetting["DB_SETTING:SCHEMA"];
    }
    public enum Connect
    {
        Read = 1,
        Write = 2
    }
    public enum Method
    {
        GET = 1,
        POST = 2,
        PUT = 3,
        DELETE = 4,
    }
}
