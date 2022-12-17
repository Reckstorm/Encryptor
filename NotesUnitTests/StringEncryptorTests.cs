using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace NotesUnitTests
{
    public class StringEncryptorTests
    {
        private static string Salt = "salt";
        private static string Value = "value";
        [Fact]
        public void StringEncryptorCryptTest()
        {
            SHA256Managed crypt = new SHA256Managed();
            byte[] bytes = Encoding.UTF8.GetBytes(Salt + Value + Salt);
            byte[] bytesHash = crypt.ComputeHash(bytes);
            Assert.Equal(StringEncryptor.Crypt(Value, Salt), bytesHash);
        }
        [Fact]
        public string StringEncryptorBuildStringTest()
        {
            byte[] bytesHash = StringEncryptor.Crypt(Value, Salt);
            StringBuilder builder = new StringBuilder();
            foreach (byte item in bytesHash)
            {
                builder.Append(item.ToString("x2"));
            }
            string str = builder.ToString();
            Assert.Equal(StringEncryptor.BuildString(bytesHash), str);
            return str;
        }
        [Fact]
        public void StringEncryptorSimpleEncTest()
        {
            Assert.NotEqual(StringEncryptorBuildStringTest(), StringEncryptor.SimpleEnc(Value));
        }
        [Fact]
        public void StringEncryptorSimpleSaltEncTest()
        {
            Assert.Equal(StringEncryptorBuildStringTest(), StringEncryptor.SimpleSaltEnc(Value, Salt));
        }
        [Fact]
        public void StringEncryptorMultiEncTest()
        {
            string data = Value;
            int counter = 2;
            for (int i = 0; i < counter; i++)
            {
                data += StringEncryptorBuildStringTest();
            }
            Assert.NotEqual(data, StringEncryptor.MultiEnc(Value, counter));
        }
        [Fact]
        public void StringEncryptorMultiSaltEncTest() 
        {
            string str = Value;
            int counter = 2;
            for (int i = 0; i < counter; i++)
            {
                str = StringEncryptor.BuildString(StringEncryptor.Crypt(str, Salt));
            }
            Assert.Equal(str, StringEncryptor.MultiSaulEnc(Value, Salt, counter));
        }
    }
}
