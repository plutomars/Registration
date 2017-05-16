using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Registration
{
    class Utility
    {
        public static String generateSHA(string s) {
            byte[] keyArray = Encoding.UTF8.GetBytes(s);
            SHA1Managed enc = new SHA1Managed();
            byte[] encodedKey = enc.ComputeHash(enc.ComputeHash(keyArray));
            StringBuilder myBuilder = new StringBuilder(encodedKey.Length);

            foreach (byte b in encodedKey)
                myBuilder.Append(b.ToString("X2"));

            return "*" + myBuilder.ToString();
        }
    }
}
