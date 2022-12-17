using Encryptor.Sources.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NotesUnitTests
{
    public class FileControllerTests
    {
        private static string path = "Users.json";
        private static string Login = "login";
        private static string Password = "Password";
        private static User User = new User(Login, Password);
        private UserList UserList = new UserList() { User };
        private FileController FileContollerObj = FileController.GetInstance();
        [Fact]
        public void FileControllerGetInstanceTest()
        {
            FileController test = FileController.GetInstance();
            Assert.True(FileContollerObj == FileController.GetInstance());
        }
        [Fact]
        public void FileControllerWriteInfoTest()
        {
            FileController.GetInstance().WriteInfo(UserList);
            Assert.True(File.Exists(path));
        }
        [Fact]
        public void FileControllerReadInfoTest()
        {
            Assert.Equal(
                JsonSerializer.Serialize<List<User>>(FileController.GetInstance().ReadInfo()), 
                JsonSerializer.Serialize<List<User>>(UserList));
        }
            
    }
}
