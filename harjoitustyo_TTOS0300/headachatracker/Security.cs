using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace headachatracker
{
    class Security
    {
        // tämä metodi muuttaa salasanan hashatuksi
        public static string ComputeSha256Hash(string rawData)
        {
            // Luodaan sha256
            SHA256 sha256Hash = SHA256.Create();

            // Lasketaan Hash - palauttaa tavutaulukon
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // Muutetaan tavutaulukko stringiksi
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                 stringBuilder.Append(bytes[i].ToString("X2")); // "X2" formatoi tavun heksadesimaaliksi, ilman sitä se on luonnollinen desimaaliluku
            }
            return stringBuilder.ToString();
        }

        // tällä metodilla luodaan salt-stringi
        public static string ComputeSaltString()
        {
            int length = 8;
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[length];
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
    }
}
