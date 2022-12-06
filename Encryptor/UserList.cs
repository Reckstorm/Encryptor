using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor
{
    internal class UserList : IDisposable
    {
        public List<User> Users { get; set; }
        public UserList() => Users = new List<User>();

        public bool LoginCheck(string login) => Users.Any(x => x.Login.Equals(login.ToLower()));

        public User Find(User temp) => Users.FirstOrDefault(x => x.Login.Equals(temp.Login.ToLower()));

        public void Dispose() => FileController.GetInstance().WriteInfo(Users);
    }
}
