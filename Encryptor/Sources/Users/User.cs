using Encryptor.Sources.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor.Sources.Users
{
    internal class User : IComparable<User>
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public NoteList Notes { get; set; }
        public User()
        {
            Login = string.Empty;
            Password = string.Empty;
            Notes = new NoteList();
        }
        public User(string login, string password)
        {
            Login = login;
            Password = password;
            Notes = new NoteList();
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
