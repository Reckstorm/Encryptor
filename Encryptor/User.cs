using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor
{
    internal class User : IComparable<User>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public User()
        {
            Login = string.Empty;
            Password = string.Empty;
        }
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public override int GetHashCode() 
        { 
            return Login.GetHashCode() + Password.GetHashCode();
        }
        public int CompareTo(User? other)
        {
            if (other is null) throw new ArgumentException("Invalid User");
            return GetHashCode() - other.GetHashCode();
        }
    }
}
