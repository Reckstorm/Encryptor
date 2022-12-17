using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesUnitTests
{
    public class UserTests
    {
        private static string Login = "Login";
        private static string Password = "Password";
        User User;
        [Fact]
        public void UserNoArgConstructorTest() 
        { 
            User = new User(); 
            Assert.True(User.Login.Equals(string.Empty));
            Assert.True(User.Password.Equals(string.Empty));
            Assert.True(User.Notes != null);
        }
        [Fact]
        public void UserArgConstructorTest()
        {
            User = new User(Login, Password);
            Assert.True(User.Login.Equals(Login));
            Assert.True(User.Password.Equals(Password));
            Assert.True(User.Notes != null);
        }
        [Fact]
        public void UserGetHashCodeTest()
        {
            User = new User(Login, Password);
            Assert.False(User.GetHashCode() == new User().GetHashCode());
        }
        [Fact]
        public void UserCompareToTest() 
        {
            User= new User(Login, Password);
            Assert.True(User.CompareTo(new User("Login", "Password")) == 0);
        }
    }
}
