using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Encryptor
{
    public static class StringEncryptor
    {
        public static byte[] Crypt(string data, string salt = "")
        {
            SHA256Managed crypt = new SHA256Managed();
            byte[] bytes = Encoding.UTF8.GetBytes(salt + data + salt);
            byte[] bytesHash = crypt.ComputeHash(bytes);
            return bytesHash;
        }

        public static string BuildString(byte[] bytesHash)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in bytesHash)
            {
                builder.Append(item.ToString("x2"));
            }
            return builder.ToString();
        }
        public static string SimpleEnc(string data) => BuildString(Crypt(data));

        public static string SimpleSaltEnc(string data, string salt = "") => BuildString(Crypt(data, salt));

        public static string MultiEnc(string data, int count = 1)
        {
            string newData = data;
            for (int i = 0; i < count; i++)
            {
                newData = SimpleEnc(newData);
            }
            return newData;
        }
        public static string MultiSaulEnc(string data, string salt = "", int count = 1)
        {
            string newData = data;
            for (int i = 0; i < count; i++)
            {
                newData = SimpleSaltEnc(newData, salt);
            }
            return newData;
        }
    }
}
