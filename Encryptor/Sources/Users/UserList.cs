namespace Encryptor.Sources.Users
{
    public class UserList : List<User>, IDisposable
    {
        public bool LoginCheck(string login) => this.Any(x => x.Login.ToLower().Equals(login.ToLower()));

        public User Find(User temp) => this.FirstOrDefault(x => x.Login.Equals(temp.Login.ToLower()));

        public void Dispose() => FileController.GetInstance().WriteInfo(this);
    }
}
