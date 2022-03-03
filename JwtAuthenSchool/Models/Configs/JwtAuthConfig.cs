namespace JwtAuthenSchool.Models.Configs
{
    public class JwtAuthConfig
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public Double Expires { get; set; } = 30!;
    }
}
