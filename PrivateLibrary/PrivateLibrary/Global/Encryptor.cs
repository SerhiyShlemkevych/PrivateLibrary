using System.Security.Cryptography;
using System.Text;

namespace EpamTask.PrivateLibrary.Global
{
    // Review IP: create an interface and implement it
    public static class Encryptor
    {
        public static string HashToMD5(string text)
        {
            var sBuilder = new StringBuilder();
            using (var md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(text));
                foreach (var t in data)
                {
                    sBuilder.Append(t.ToString("x2"));
                }
            }
            return sBuilder.ToString();
        }
    }
}
