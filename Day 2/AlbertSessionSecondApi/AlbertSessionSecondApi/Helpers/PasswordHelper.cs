using System.Security.Cryptography;
using System.Text;

namespace AlbertSessionSecondApi.Helpers
{
    public static class PasswordHelper
    {
        private static readonly int saltLength = 8;

        public static string hashPassword(string input)
        {
            string salt = GenerateSalt(saltLength);
            byte[] hashBytes = SHA256Hash(input + salt);
            string base64Hash = Convert.ToBase64String(hashBytes);
            return salt + base64Hash;
        }

        public static bool verifyPassword(string enteredPassword,string storedValue)
        {
            if(storedValue.Length< saltLength)
            {
                return false;

            }

            string salt = storedValue.Substring(0, saltLength);
            string expectedHash = storedValue.Substring(saltLength);


            byte[] hashBytes = SHA256Hash(enteredPassword + salt);
            string enteredHash = Convert.ToBase64String(hashBytes);

            return expectedHash == enteredHash;



        }



        private static byte[] SHA256Hash(string input)
        {
            using(SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }


        private static string GenerateSalt(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Range(0, length)
                .Select(_ => chars[random.Next(chars.Length)]).ToArray());
        }
    }
}
