using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using System.ComponentModel;

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

        public static DataTable createPartiesTable() {
            List<Parties> list;
            using (StreamReader sr = new StreamReader(@".\party.json")) {
                string s = sr.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Parties>>(s);
            }
            return listToTable<Parties>(list);
        }

        public static DataTable createStatesTable() {
            List<States> list;
            using (StreamReader sr = new StreamReader(@".\states.json")) {
                string s = sr.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<States>>(s);
            }
            return listToTable<States>(list);
        }

        private static DataTable listToTable<T>(List<T> data) {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();
            for (int i = 0; i < props.Count; i++) {
                PropertyDescriptor pd = props[i];
                dt.Columns.Add(pd.Name, pd.PropertyType);
            }

            object[] values = new object[props.Count];
            foreach (T item in data) {
                for (int i = 0; i < values.Length; i++) {
                    values[i] = props[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }

    }

    class States {
        public string fullname { get; set; }
        public string abbreviation { get; set; }
    }

    class Parties {
        public string party_type { get; set; }
        public string value { get; set; }
    }


}
