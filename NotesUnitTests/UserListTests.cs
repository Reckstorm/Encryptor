using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesUnitTests
{
    public class UserListTests
    {
        private static string path = "Users.json";
        private static string Login = "login";
        private static string Password = "Password";
        private static User User = new User(Login, Password);
        UserList UserList = new UserList();
        [Fact]
        public void UserListLoginCheckTest()
        {
            UserList.Add(User);
            Assert.True(UserList.LoginCheck(Login));
        }
        [Fact]
        public void UserListFindTest()
        {
            UserList.Add(User);
            Assert.True(UserList.Find(User).CompareTo(new User(Login, Password)) == 0);
        }
        [Fact]
        public void UserListDisposeTest()
        {
            UserList.Dispose();
            Assert.True(File.Exists(path));
        }
    }
}
