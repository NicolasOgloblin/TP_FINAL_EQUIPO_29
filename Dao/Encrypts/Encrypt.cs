using System;
using System.Security.Cryptography;
using System.Text;

namespace Dao.Encrypts
{
    public class Encrypt 
    {
        public string HashPasswordWithSalt(string password, string salt)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string saltedPassword = password + salt;
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        public string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            string enteredHash = HashPasswordWithSalt(enteredPassword, storedSalt);
            return enteredHash == storedHash;
        }
        
    }
}
