using System.ComponentModel.DataAnnotations;

namespace JwtAuthenSchool.Models.Authentication
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class UserModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public int Result { set; get; }
    }
}
