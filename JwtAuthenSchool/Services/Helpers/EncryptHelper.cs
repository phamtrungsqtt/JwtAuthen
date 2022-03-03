using System.Security.Cryptography;
using System.Text;

namespace JwtAuthenSchool.Services.Helpers
{
    public class EncryptHelper
    {
        public static string Encrypt(string original)
        {
            return Encrypt(original, "!@#$%^&*()~_+|");
        }

        public static string Encrypt(string original, string key)
        {
            TripleDESCryptoServiceProvider objDESProvider;
            MD5CryptoServiceProvider objHashMD5Provider;
            byte[] keyhash;
            byte[] buffer;
            try
            {
                objHashMD5Provider = new MD5CryptoServiceProvider();
                keyhash = objHashMD5Provider.ComputeHash(UnicodeEncoding.Unicode.GetBytes(key));
                objHashMD5Provider = null;

                objDESProvider = new TripleDESCryptoServiceProvider();
                objDESProvider.Key = keyhash;
                objDESProvider.Mode = CipherMode.ECB;

                buffer = UnicodeEncoding.Unicode.GetBytes(original);
                return Convert.ToBase64String(objDESProvider.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception ex)
            {

                return string.Empty;
            }
        }

        public static string Decrypt(string encrypted)
        {
            return Decrypt(encrypted, "!@#$%^&*()~_+|");
        }

        public static string Decrypt(string encrypted, string key)
        {
            TripleDESCryptoServiceProvider objDESProvider;
            MD5CryptoServiceProvider objHashMD5Provider;
            byte[] keyhash;
            byte[] buffer;

            try
            {
                objHashMD5Provider = new MD5CryptoServiceProvider();
                keyhash = objHashMD5Provider.ComputeHash(UnicodeEncoding.Unicode.GetBytes(key));
                objHashMD5Provider = null;

                objDESProvider = new TripleDESCryptoServiceProvider();
                objDESProvider.Key = keyhash;
                objDESProvider.Mode = CipherMode.ECB;

                buffer = Convert.FromBase64String(encrypted);
                return UnicodeEncoding.Unicode.GetString(objDESProvider.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception ex)
            {

                return string.Empty;
            }
        }
    }
}
