using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Encryptor.Sources.Users;

namespace Encryptor
{
    public sealed class FileController
    {
        private string path = "Users.json";

        private static FileController _instance;

        private FileController(){ }
        public static FileController GetInstance() 
        {
            if (_instance == null)
            {
                _instance = new FileController();
            }
            return _instance; 
        }

        public void WriteInfo(List<User> list) => File.WriteAllText(path, JsonSerializer.Serialize(list));
        public UserList ReadInfo()
        {
            UserList temp = new UserList();
            if (File.Exists(path))
            {
                string tempUsers = File.ReadAllText(path);
                temp.AddRange(JsonSerializer.Deserialize<List<User>>(tempUsers));
            }
            return temp;
        }
    }
}
