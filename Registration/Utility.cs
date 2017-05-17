using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


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

        public static void createStatesTable() {
            JObject obj = JObject.Parse(File.ReadAllText(@".\states.json"));
            List<JObject> list = new List<JObject>();

            using (StreamReader file = File.OpenText(@".\states.json"))
            using (JsonTextReader reader = new JsonTextReader(file)) {
                JObject states = (JObject)JToken.ReadFrom(reader);
                list.Add(states);
            }

            
        }

    }
}
